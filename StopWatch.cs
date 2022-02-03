using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ShanOS.Utilities {
    /// <summary>
    /// StopWatch Class
    /// </summary>
    public static class StopWatch {
        /// <summary>
        /// Dictionary Mapping GUID and Stopwatch 
        /// </summary>
        /// <typeparam name="string">unique guid string</typeparam>
        /// <typeparam name="Stopwatch">Stopwatch object</typeparam>
        /// <returns>Dictionary Mapping containing GUID and Stopwatch </returns>
        private static Dictionary<string, Stopwatch> nestedStopwatch = new Dictionary<string, Stopwatch> ();
        /// <summary>
        /// Start Timer, to track the time elapsed.
        /// </summary>
        /// <returns>unique GUID string </returns>
        public static string StartTimer () {
            Guid guid = Guid.NewGuid ();

            string validator = guid.ToString ();
            Stopwatch watch = new System.Diagnostics.Stopwatch ();
            watch.Start ();
            nestedStopwatch.Add (validator, watch);

            return validator;
        }

        /// <summary>
        /// Stop Timer, to store the time elapsed
        /// </summary>
        /// <param name="validator">unique GUID</param>
        /// <returns>Elapsed time in milliseconds</returns>
        public static long StopTimer (string validator) {
            Stopwatch watch;
            nestedStopwatch.TryGetValue (validator, out watch);
            watch.Stop ();
            return watch.ElapsedMilliseconds;
        }

        /// <summary>
        /// To Convert milliseconds to String 
        /// </summary>
        /// <param name="milliseconds">input milliseconds</param>
        /// <returns>returns time span in human readable format</returns>
        public static string ToConvertString (long milliseconds) {
            return string.Format (new TimeSpan (milliseconds).ToString ());
        }
    }
}