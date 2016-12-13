﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleASPNetSample.Models;
using SimpleASPNetSample.Services.Interfaces;
using System.Diagnostics;
using SimpleASPNetSample.Context;
using SimpleASPNetSample.RestViewModel;
using SimpleASPNetSample.Interfaces;

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


        private ViewModelUltraSonicSensorRun ConvertSensorRunModelToViewModel(UltraSonicSensorRun ultraSonicSensorRun)
        {
            ViewModelUltraSonicSensorRun viewModelLastUltraSonic = null;
            using (var db = new UltraSonicContext())
            {
                if (ultraSonicSensorRun != null)
                {
                    viewModelLastUltraSonic = new ViewModelUltraSonicSensorRun(ultraSonicSensorRun);

                    ultraSonicSensorRun.SonicMeasurements = (from measurement in db.UltraSonicSensorRunMeasurements
                                                             where measurement.UltraSonicSensorRunId == ultraSonicSensorRun.SonicId
                                                             select measurement).ToList<UltraSonicSensorRunMeasurement>();
                    viewModelLastUltraSonic.SonicMeasurements = new List<IUltraSonicSensorRunMeasurement>();
                    foreach (var measurement in ultraSonicSensorRun.SonicMeasurements)
                    {
                        viewModelLastUltraSonic.SonicMeasurements.Add(new ViewModelUltraSonicSensorRunMeasurement(measurement));
                    }
                }
            }
            return viewModelLastUltraSonic;
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


        public bool IsUltraSonicServiceRunning()
        {
            return (_isUltraSonicRunning);           
        }


        public long RemoveAllUltraSonicRuns()
        {
            long ultraSonicRunsRemoved = 0;
            using (var db = new UltraSonicContext())
            {
                ultraSonicRunsRemoved  = db.UltraSonicSensorRuns.Count();
                db.UltraSonicSensorRunMeasurements.RemoveRange(db.UltraSonicSensorRunMeasurements);
                db.UltraSonicSensorRuns.RemoveRange(db.UltraSonicSensorRuns);
                db.SaveChangesAsync();
            }

            return ultraSonicRunsRemoved;
        }


        public ViewModelUltraSonicSensorRun RetrieveLatestUltraSonicRun()
        {
            UltraSonicSensorRun LastUltraSonic = null;
            ViewModelUltraSonicSensorRun viewModelLastUltraSonic = null;

            using (var db = new UltraSonicContext())
            {
                var qResult = (from sensorRun in db.UltraSonicSensorRuns                                  
                                  orderby sensorRun.RunDate descending
                                  select sensorRun);
                viewModelLastUltraSonic = ConvertSensorRunModelToViewModel(qResult.FirstOrDefault());
            }
            return viewModelLastUltraSonic;
        }

       
        public List<ViewModelUltraSonicSensorRun> RetrieveAllRuns()
        {
            List<UltraSonicSensorRun> ultraSonicRuns;
            List<ViewModelUltraSonicSensorRun> viewModelUltraSonicSensorRuns = null;

            using (var db = new UltraSonicContext())
            {
                ultraSonicRuns = (from sensorRun in db.UltraSonicSensorRuns
                                  select sensorRun).ToList<UltraSonicSensorRun>();
            }

            if (ultraSonicRuns.Any())
            {
                viewModelUltraSonicSensorRuns = new List<ViewModelUltraSonicSensorRun>();
                foreach (var ultraSonicRun in ultraSonicRuns)
                {
                    viewModelUltraSonicSensorRuns.Add(ConvertSensorRunModelToViewModel(ultraSonicRun));
                }

            }            

            return viewModelUltraSonicSensorRuns;
        }


        public ViewModelUltraSonicSensorRun RetrieveUltraSonicRun(long RunId)
        {
            ViewModelUltraSonicSensorRun viewModelLastUltraSonic = null;
            UltraSonicSensorRun LastUltraSonic = null;
            using (var db = new UltraSonicContext())
            {
                LastUltraSonic = (from sensorRun in db.UltraSonicSensorRuns
                                  where sensorRun.SonicId == RunId
                                  select sensorRun).FirstOrDefault();
            }

            viewModelLastUltraSonic = ConvertSensorRunModelToViewModel(LastUltraSonic);

            return viewModelLastUltraSonic;
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
                        Debug.WriteLine($"Hello From Thread time elapsed {stopWatch.ElapsedMilliseconds}");
                        UltraSonicSensorRunMeasurement measurement = new UltraSonicSensorRunMeasurement();
                      
                        lastMeasurement += .1;
                        measurement.MeasurementDistance = lastMeasurement;
                        measurement.TimeOfMeasurment = DateTime.Now;
                       
                        //Set values from Sonic Sensor Run
                        measurement.Run = SonicSensorRun;
                        measurement.MeasurementGUID = Guid.NewGuid().ToString();
                        measurement.UltraSonicSensorRunId = SonicSensorRun.SonicId;
                        measurement.SonicGUID = SonicSensorRun.SonicGUID;
                                             
                        SonicSensorRun.SonicMeasurements.Add(measurement);
                    }
                    //save UltraSonic Run to sqllite database
                    using (var db = new UltraSonicContext())
                    {
                       var SonicEnity = db.UltraSonicSensorRuns.Add(SonicSensorRun);
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

     
    }
}
