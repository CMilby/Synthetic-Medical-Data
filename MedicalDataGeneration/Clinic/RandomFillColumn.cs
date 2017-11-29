
namespace MedicalDataGeneration.Clinic {

	public class RandomFillColumn : Column {

		private Random Random;
		private Column Column;

		private float FillChance;

		public RandomFillColumn ( string p_header, float p_chance, Random p_random, Column p_column ) : base ( p_header ) {
			FillChance = p_chance;
			Random = p_random;
			Column = p_column;
		}

		public override string Generate() {
			if ( Random.NextFloat () < FillChance ) {
				return Column.Generate ( );
			}

			return "";
		}
	}
}
