using Microsoft.Practices.ServiceLocation;
using NdubuisiJr.Z_Digit.Domain;
using NdubuisiJr.Z_Digit.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NdubuisiJr.Z_Digit.Module.Utils {
    public class Calculators {
        public Calculators() {
            data = ServiceLocator.Current.GetInstance<IDataService>();
        }

        public ZFactorChart GetCurveFromTemperature(double temp) {
            return GetAllCurves().FirstOrDefault(x => x.PseudoReducedTemperature >= temp);
        }

        public WorkingChart ZfactorReduced(double temp, double pres) {
            return Calculator(temp, pres);
        }
        public WorkingChart ZfactorCritical(double temp, double pres) {
            return Calculator(temp, pres);
        }

        private WorkingChart Calculator(double temp, double pres) {
            var zfactor = 0.0;
            var allCurves = GetAllCurves();

            var curvebeingSearched = allCurves.FirstOrDefault(x => x.PseudoReducedTemperature >= temp);

            zfactor = CalculateZfactor(pres, zfactor, curvebeingSearched);
            zfactor = Math.Round(zfactor, 5);
            return new WorkingChart {
                Zfactor = zfactor,
                ZfactorChart = curvebeingSearched,
                Pressure = pres
            };
        }

        private static double CalculateZfactor(double pres, double zfactor, ZFactorChart curvebeingSearched) {
            if (curvebeingSearched == null) { throw new ArgumentException("Invalid"); }

            if (curvebeingSearched.PseudoReducedPressures.Contains(pres)) {
                var index = curvebeingSearched.PseudoReducedPressures.
                                              FindIndex(x => x == pres);
                zfactor = curvebeingSearched.ZFactors[index];
            }
            else {
                var index2 = curvebeingSearched.PseudoReducedPressures
                                               .FindIndex(x => x > pres);
                var index1 = index2 - 1;
                if (index2 > -1) {
                    var x2 = curvebeingSearched.PseudoReducedPressures[index2];
                    var x1 = curvebeingSearched.PseudoReducedPressures[index1];

                    var fx2 = curvebeingSearched.ZFactors[index2];
                    var fx1 = curvebeingSearched.ZFactors[index1];

                    var m = (fx2 - fx1) / (x2 - x1);

                    zfactor = fx1 + (m * (pres - x1));
                }

            }

            return zfactor;
        }
        public IEnumerable<ZFactorChart> GetAllCurves() {
            return data.GetData();
        }
        public IDataService data {
            get;
            private set;
        }
    }
}
