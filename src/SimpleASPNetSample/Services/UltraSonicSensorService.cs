using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleASPNetSample.Models;
using SimpleASPNetSample.Services.Interfaces;
using SimpleASPNetSample.Threading;
using System.Threading;
using System.Diagnostics;
using SimpleASPNetSample.Context;

namespace SimpleASPNetSample.Services
{
    public class UltraSonicSensorService : IUltraSonicSensor
    {

        private static UltraSonicSensorService _instance;
        private static Task<bool> _BackgroundThread;
        private static bool _isUltraSonicRunning;
        private Action<UltraSonicRunRequest> _ActionUltraSonicRun;

        private UltraSonicSensorService()
        {
           
        }

        public static UltraSonicSensorService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UltraSonicSensorService();
                }
                return _instance;
            }
        }
       
        public UltraSonicSensorRun RetrieveLatestUltraSonicRun()
        {
            UltraSonicSensorRun LastUltraSonic = null;

            using (var db = new UltraSonicContext())
            {
                LastUltraSonic = (from sensorRun in db.UltraSonicSensorRuns                                  
                                  orderby sensorRun.RunDate
                                  select sensorRun).FirstOrDefault() ;
                
                if (LastUltraSonic != null)
                      LastUltraSonic.SonicMeasurements = (from measurement in db.UltraSonicSensorRunMeasurements
                                                    where measurement.UltraSonicSensorRunId == LastUltraSonic.SonicId
                                                    select measurement).ToList<UltraSonicSensorRunMeasurement>();              

            }

            return LastUltraSonic;
        }

      

        public bool StartUltraSonicRun(UltraSonicRunRequest runrequest)
        {
            bool StartUltraSonicRunResult = false;

            if (!(_isUltraSonicRunning))
            {
                _isUltraSonicRunning = true;
                StartUltraSonicRunResult = true;

                _BackgroundThread = new Task<bool>(() =>
                {
                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();

                    double lastMeasurement = 5;
                    UltraSonicSensorRun SonicSensorRun = new UltraSonicSensorRun();
                    SonicSensorRun.SonicMeasurements = new List<UltraSonicSensorRunMeasurement>();

                    while (stopWatch.ElapsedMilliseconds < runrequest.TimeInSecondsToRunSensor * 1000)
                    {
                        Task.Delay(100).Wait();
                        Debug.WriteLine($"Hello From Thread time elapsed {stopWatch.ElapsedMilliseconds}" );
                        UltraSonicSensorRunMeasurement measurement = new UltraSonicSensorRunMeasurement();
                        measurement.Run = SonicSensorRun;
                        lastMeasurement += .1;
                        measurement.MeasurementDistance = lastMeasurement;
                        measurement.TimeOfMeasurment = DateTime.Now;
                        SonicSensorRun.SonicMeasurements.Add(measurement);
                    }
                    //save UltraSonic Run to sqllite database
                    using (var db = new UltraSonicContext())
                    {
                        db.UltraSonicSensorRuns.Add(SonicSensorRun);
                        foreach (var sonicMeasurement in SonicSensorRun.SonicMeasurements)
                        {
                            db.UltraSonicSensorRunMeasurements.Add(sonicMeasurement);
                        }
                        db.SaveChanges();
                    }
                    _isUltraSonicRunning = false;
                    return true;
                });
                _BackgroundThread.Start();
            }
           
            return StartUltraSonicRunResult;
        }

        public List<UltraSonicSensorRun> RetrieveAllRuns()
        {
            List<UltraSonicSensorRun> ultraSonicRuns;

            using (var db = new UltraSonicContext())
            {
                ultraSonicRuns = (from sensorRun in db.UltraSonicSensorRuns                                  
                                  select sensorRun).ToList<UltraSonicSensorRun>();

                foreach (var ultrarun in ultraSonicRuns)
                {
                    ultrarun.SonicMeasurements = (from measurement in db.UltraSonicSensorRunMeasurements
                                                        where measurement.UltraSonicSensorRunId == ultrarun.SonicId
                                                        select measurement).ToList<UltraSonicSensorRunMeasurement>();
                }
            }

            return ultraSonicRuns;
        }

        public UltraSonicSensorRun RetrieveUltraSonicRun(int RunId)
        {
            throw new NotImplementedException();
        }

        public bool IsUltraSonicServiceRunning()
        {
            throw new NotImplementedException();
        }
    }
}
