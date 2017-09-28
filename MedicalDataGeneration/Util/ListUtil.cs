using System;
using System.Collections;
using System.Collections.Generic;

namespace MedicalDataGeneration {
	
	static class ListUtil {

		public static void Shuffle<T> ( this IList<T> p_list, Random p_random ) {
			int n = p_list.Count;
			while ( n > 1 ) {
				n--;
				int k = p_random.Next ( n + 1 );
				T value = p_list [ k ];
				p_list [ k ] = p_list [ n ];
				p_list [ n ] = value;
			}
		}
	}
}

