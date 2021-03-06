﻿using SimpleASPNetSample.Configuration.Interfaces;
using SimpleASPNetSample.Context;
using SimpleASPNetSample.Interfaces;
using SimpleASPNetSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleASPNetSample.Configuration
{
     internal  class PiNameValuePairDBSettings: IPiNameValuePairDBSettings
    {

        public void CopyKeyValuePair(IPiNameValuePair from, IPiNameValuePair to)
        {
            to.Name = from.Name;
            to.Value = from.Value;
        }


        public bool DeleteNameValuePair(string PairName)
        {
            using (var db = new PiGeneralContext())
            {
                var PairToDelete = (from ValuePairs in db.PiNameValuePairs
                                    where ValuePairs.Name.ToUpper() == PairName.ToUpper()
                                    select ValuePairs).FirstOrDefault();

                if (PairToDelete != null)
                {
                    db.PiNameValuePairs.Remove(PairToDelete);
                    return true;
                }
            }

            return false;
        }

        public List<IPiNameValuePair> GetAllNameValuePairs()
        {
            List<IPiNameValuePair> retValues;
            using (var db = new PiGeneralContext())
            {
                retValues = db.PiNameValuePairs.ToList<IPiNameValuePair>();
            }
            return retValues;
        }




        public PiNameValuePair GetPiNameValuePair(string PairName)
        {
            using (var db = new PiGeneralContext())
            {
                var PairToFind = (from ValuePairs in db.PiNameValuePairs
                                  where ValuePairs.Name.ToUpper() == PairName.ToUpper()
                                  select ValuePairs).FirstOrDefault();

                if (PairToFind != null)
                {
                    return PairToFind;
                }

            }
            return null;
        }


        public PiNameValuePair GetPiNameValuePair(string PairName, string DefaultValue)
        {
            var PairToFind = GetPiNameValuePair(PairName);
            if (PairToFind != null)
            {
                return PairToFind;
            }
            else
            {
                PairToFind = new PiNameValuePair() { Name = PairName, Value = DefaultValue };
            }

            return null;
        }

        public bool SetAllNameValuePairs(List<IPiNameValuePair> AzureValuePairs)
        {

            foreach (var AzureValuePair in AzureValuePairs)
            {
                var PairToFind = GetPiNameValuePair(AzureValuePair.Name);
                if (PairToFind != null)
                {
                    if (SetNameValuePair(AzureValuePair.Name, AzureValuePair.Value) == false)
                        return false;
                }
            }

            return true;
        }

        public bool SetNameValuePair(string PairName, string Value)
        {
            using (var db = new PiGeneralContext())
            {
                var PairToModify = GetPiNameValuePair(PairName);

                if (PairToModify != null)
                {
                    PairToModify.Value = Value;
                    db.PiNameValuePairs.Update(PairToModify);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    PairToModify = new PiNameValuePair();
                    PairToModify.Value = Value;
                    PairToModify.Name = PairName;
                    db.PiNameValuePairs.Add(PairToModify);
                    db.SaveChanges();
                }

            }
            return false;
        }


      

        /// <summary>
        /// Sets the value of the key value pair if one does not
        /// already exists vpn
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Value"></param>
        /// <returns> flase if value already exists returns true if added a new value</returns>
        public bool SetValueIfOneDoesNotExist(string PairName, string Value)
        {
            var PairToFind = GetPiNameValuePair(PairName);
            if (PairToFind == null)
            {
                SetNameValuePair(PairName, Value);
            }
            return false;
        }
    }
}
