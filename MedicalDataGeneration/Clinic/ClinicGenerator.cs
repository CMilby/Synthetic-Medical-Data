using System.IO;

namespace MedicalDataGeneration.Clinic {

	public class ClinicGenerator {

		private Random Random;

		public ClinicGenerator ( string p_outFile, int p_numLines, long p_seed ) {
			Random = new Random ( p_seed );

			Generate ( p_outFile, p_numLines );
		}

		private Column[] GenColumns ( Random p_random ) {
			PatientColumn patient = new PatientColumn ( Random );
			DoctorColumn attendingDoctor = new DoctorColumn ( Random, "Attending" );
			DoctorColumn orderingDoctor = new DoctorColumn ( Random, "Ordering" );

			Column [ ] columns = new Column [ ] {
				patient [ PatientColumn.ePatientColumns.FIRST_NAME ],
				new EmptyColumn ( "FirstAddendingFirstName" ),
				new RandomFillColumn ( "TechnicalAccountingUnit", 0.35f, p_random, new RandomNumberColumn ( "TechnicalAccountingUnit", p_random, 100000, 999999, 6 ) ),
				new RandomFillColumn ( "LastSigningEmployeeTypeId", 0.5f, p_random, new ConstantColumn ( "LastSigningEmployeeTypeId", "10" ) ),
				new RandomFillColumn ( "CancelDescription", 0.2f, p_random, new ConstantColumn ( "CancelDescription", "MISCELLANEOUS" ) ),
				new ConstantColumn ( "Type", "Study" ),
				new EmptyColumn ( "ProcedureSubspeciality" ), // TODO
				orderingDoctor [ DoctorColumn.eDoctorColumns.NPI ],
				new ConstantColumn ( "ProcedureReason", "Test" ),
				new RandomFillColumn ( "FirstAddendingEmployeeTypeDescription", 0.1f, p_random, new ConstantColumn ( "FirstAddendingEmployeeTypeDescription", "Staff" ) ),
				new IncrementalColumn ( "ID", 100000 ),
				patient [ PatientColumn.ePatientColumns.DATE_OF_BIRTH ],
				new EmptyColumn ( "LateralityDescription" ),
				new ConstantColumn ( "IsReportable", "1" ),
				new EmptyColumn ( "MRNAssigningAuthority" ),
				new EmptyColumn ( "FirstReadingEmployeeTypeDescription" ),
				new EmptyColumn ( "LeftDepartmentDateTime" ),
				new EmptyColumn ( "IsFamilyHealthCenter" ),
				new EmptyColumn ( "Impression" ),
				new EmptyColumn ( "LastSigningEmployeeTypeDescription" ),
				new EmptyColumn ( "OrderingDoctorNumber" ),
				new EmptyColumn ( "LastSigningDateTime" ),
				new EmptyColumn ( "FirstReadingLastName" ),
				new EmptyColumn ( "HospitalCode" ),
				new EmptyColumn ( "FirstAddendingEmployeeTypeID" ),
				orderingDoctor [ DoctorColumn.eDoctorColumns.LAST_NAME ],
				new EmptyColumn ( "EnterDepartmentDateTime" ),
				patient [ PatientColumn.ePatientColumns.LAST_NAME ],
				new EmptyColumn ( "OrderingDoctorMiddleName" ),
				new EmptyColumn ( "HospitalDescription" ),
				new EmptyColumn ( "ProcedureCode" ),
				new EmptyColumn ( "LateralityCode" ),
				new EmptyColumn ( "LastSigningNPI" ),
				patient [ PatientColumn.ePatientColumns.SEX ],
				new EmptyColumn ( "AttendingDoctorMiddleName" ),
				new EmptyColumn ( "MRN" ),
				new EmptyColumn ( "PatientClassCode" ),
				new EmptyColumn ( "FirstSigningDateTime" ),
				new EmptyColumn ( "LastSigningFirstName" ),
				new EmptyColumn ( "FirstSigningMiddleName" ),
				new EmptyColumn ( "FirstAddendingNPI" ),
				new EmptyColumn ( "ProcedureDescription" ),
				new EmptyColumn ( "EnterpriseMRN" ),
				patient [ PatientColumn.ePatientColumns.AGE_END ],
				new EmptyColumn ( "FirstReadingMiddleName" ),
				new EmptyColumn ( "DepartmentKey" ),
				new EmptyColumn ( "Accession" ),
				new EmptyColumn ( "OrderedForDateTime" ),
				new EmptyColumn ( "LastSigningMiddleName" ),
				new EmptyColumn ( "StudyTypeCPTCode" ),
				new EmptyColumn ( "FirstReadingDateTime" ),
				new EmptyColumn ( "BeginProcedureDateTime" ),
				new EmptyColumn ( "FirstAddendingLastName" ),
				new EmptyColumn ( "BodyPart" ),
				new EmptyColumn ( "TotalImagesWithinStudy" ),
				new EmptyColumn ( "FirstReadingNPI" ),
				new EmptyColumn ( "FirstAddendumDateTime" ),
				new EmptyColumn ( "PatientClassDescription" ),
				new EmptyColumn ( "FirstSigningEmployeeTypeID" ),
				new EmptyColumn ( "ModalityDescription" ),
				new EmptyColumn ( "FirstReadingDoctorKey" ),
				new EmptyColumn ( "LastSigningDoctorKey" ),
				new EmptyColumn ( "FirstAddendingMiddleName" ),
				new EmptyColumn ( "ResourceKey" ),
				new EmptyColumn ( "AttendingDoctorNPI" ),
				new EmptyColumn ( "OriginalOrderedOnDateTime" ),
				new EmptyColumn ( "FirstReadingEmployeeTypeID" ),
				attendingDoctor [ DoctorColumn.eDoctorColumns.FIRST_NAME ],
				new EmptyColumn ( "AttendingDoctorNumber" ),
				new EmptyColumn ( "FirstSigningNPI" ),
				new EmptyColumn ( "OrderingDoctorSKey" ),
				new EmptyColumn ( "DepartmentLongName" ),
				new EmptyColumn ( "FirstSigningEmployeeTypeDescription" ),
				orderingDoctor [ DoctorColumn.eDoctorColumns.FIRST_NAME ],
				new EmptyColumn ( "ModalityCode" ),
				new EmptyColumn ( "FirstSigningLastName" ),
				new EmptyColumn ( "ProcedurePriority" ),
				new EmptyColumn ( "StudySKey" ),
				new EmptyColumn ( "ProcedureIsActive" ),
				new EmptyColumn ( "FirstSigningDoctorKey" ),
				new EmptyColumn ( "EndProcedureDateTime" ),
				new EmptyColumn ( "DepartmentCode" ),
				new EmptyColumn ( "ResourceCode" ),
				new EmptyColumn ( "AttendingDoctorSKey" ),
				new EmptyColumn ( "OrderedOnDateTime" ),
				new EmptyColumn ( "VisitDiagnosis" ),
				new ConstantColumn ( "IsBilled", "1" ),
				new EmptyColumn ( "FirstAddendingDoctorKey" ),
				attendingDoctor [ DoctorColumn.eDoctorColumns.LAST_NAME ],
				new EmptyColumn ( "FirstSigningFirstName" ),
				new EmptyColumn ( "ResourceDescription" ),
				new EmptyColumn ( "PatientMiddleName" ),
				new EmptyColumn ( "LastSigningLastName" ),
				new EmptyColumn ( "CancelCode" ),
				new EmptyColumn ( "FirstReadingFirstName" ),
				new EmptyColumn ( "StudyTypeCPTDescription" )
			};

			return columns;
		}

		private void Generate( string p_outFile, int p_lineNums ) {
			FileStream fs = new FileStream ( p_outFile, FileMode.Create );

			Column [ ] columns = GenColumns ( Random );

			using ( StreamWriter sw = new StreamWriter ( fs ) ) {
				for ( int j = 0; j < columns.Length; j++ ) {
					sw.Write ( columns [ j ].Header );
					if ( j != columns.Length - 1 ) {
						sw.Write ( "," );
					}
				}

				sw.WriteLine ( "" );

				for ( int i = 0; i < p_lineNums; i++ ) {
					for ( int j = 0; j < columns.Length; j++ ) {
						sw.Write ( columns [ j ].Generate ( ) );
						if ( j != columns.Length - 1 ) {
							sw.Write ( "," );
						}
					}

					sw.WriteLine ( "" );
					columns = GenColumns ( Random );
				}
			}
		}
	}
}
