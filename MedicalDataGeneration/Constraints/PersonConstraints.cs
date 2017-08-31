using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalDataGeneration.Constraints {

	public class PersonConstraints {
		
		// White, African American, Asian, Other
		public static float[ , ] sRaceRatios = {  { 89.8f,  9.8f, 0.1f, 0.3f  }, // 1940
												  { 89.5f, 10.0f, 0.2f, 0.3f  }, // 1950
												  { 88.6f, 10.5f, 0.4f, 0.5f  }, // 1960
												  { 87.5f, 11.1f, 0.6f, 0.8f  }, // 1970
												  { 83.0f, 11.7f, 1.5f, 3.8f  }, // 1980
												  { 80.3f, 12.1f, 2.9f, 4.7f  }, // 1990
												  { 75.1f, 12.3f, 3.8f, 8.8f  }, // 2000
												  { 72.4f, 12.6f, 5.0f, 10.0f }, // 2010
		};
	}
}
