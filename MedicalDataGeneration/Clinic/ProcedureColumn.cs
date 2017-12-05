using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalDataGeneration.Clinic {

	public class ProcedureColumn : MultivalueColumn {

		public enum eProcedureColumns {
			MODE_DESCRIPTION,
			MODE_CODE,
			PROCEDURE_DESCRIPTION,
			BODY_PART,
			PROCEDURE_CODE
		}

		private Procedure Procedure;
		
		public ProcedureColumn ( Random p_random ) : base ( p_random ) {
			Procedure = ProcedurePool.GetProcedure ( p_random );

			HeaderMapper.Add ( "MODE_DESCRIPTION", GetModeDescription );
			HeaderMapper.Add ( "MODE_CODE", GetModeCode );
			HeaderMapper.Add ( "PROCEDURE_DESCRIPTION", GetProcedureDescription );
			HeaderMapper.Add ( "BODY_PART", GetBodyPart );
			HeaderMapper.Add ( "PROCEDURE_CODE", GetProcedureCode );
		}

		public ConstantColumn GetProcedureCode ( ) {
			return new ConstantColumn ( "ProcedureCode", Procedure.ModeCode + " " + Random.Next ( 1000, 9999 ) );
		}

		public ConstantColumn GetModeDescription ( ) {
			return new ConstantColumn ( "ModalityDescription", Procedure.ModeDescription );
		}

		public ConstantColumn GetModeCode ( ) {
			return new ConstantColumn ( "ModalityCode", Procedure.ModeCode );
		}

		public ConstantColumn GetProcedureDescription ( ) {
			return new ConstantColumn ( "ProcedureDescription", Procedure.ProcedureDescription );
		}

		public ConstantColumn GetBodyPart ( ) {
			return new ConstantColumn ( "BodyPart", Procedure.BodyPart );
		}

		public Column this [ eProcedureColumns p_column ] {
			get {
				return HeaderMapper [ p_column.ToString ( ) ] ( );
			}
		}

		public override string Generate() {
			return "";
		}

		public override string GetHeader() {
			return "";
		}
	}

	public class Procedure {

		public string ModeDescription { get; set; }
		public string ModeCode { get; set; }
		public string ProcedureDescription { get; set; }
		public string BodyPart { get; set; }

		public Procedure ( string p_modeDesc, string p_modeCode, string p_procedureDesc, string p_bodyPart ) {
			ModeDescription = p_modeDesc;
			ModeCode = p_modeCode;
			ProcedureDescription = p_procedureDesc;
			BodyPart = p_bodyPart;
		}
	}

	public class ProcedurePool {

		public static List<Procedure> Procedures;

		static ProcedurePool ( ) {
			LoadProcedures ( );
		}

		public static Procedure GetProcedure ( Random p_random ) {
			return Procedures [ p_random.Next ( 0, Procedures.Count - 1 ) ];
		}

		private static void LoadProcedures ( ) {
			Procedures = new List<Procedure> ( 149 ) {
				new Procedure ( "Magnetic Resonance Imaging","MR","MRI KNEE WO IVCON LT","MSK-KNEE" ),
				new Procedure ( "Magnetic Resonance Imaging","MR","MRI CARD MORPH FUNC WO/W IVCON","CARDIAC" ),
				new Procedure ( "Ultrasound","US","US BREAST INCL AXILLA COMP BIL","UNDEFINED" ),
				new Procedure ( "Ultrasound","US","US RETROPERITONEUM-COMP","ABDOMEN" ),
				new Procedure ( "X-Ray","XR","XR HIP AP/FROG LAT W PELV RT","HIP" ),
				new Procedure ( "X-Ray","XR","XR KNEE AP/LAT/MERCHANT","MSK-KNEE" ),
				new Procedure ( "X-Ray","XR","XR SCOLIOSIS AP/LAT STAND","SPINE" ),
				new Procedure ( "Ultrasound","US","US TRANSVAGINAL OBS","PELVIS" ),
				new Procedure ( "Mammography","MM","MAM CLINIC SCREEN DIG CAD BIL","BREAST" ),
				new Procedure ( "X-Ray","XR","XR WRIST M3V UNI","WRIST" ),
				new Procedure ( "X-Ray","XR","XR KNEE AP/LAT/MERCHANT","KNEE" ),
				new Procedure ( "Nuclear Medicine","NM","NM GASTRIC EMPTYING SOLID","ABDOMEN" ),
				new Procedure ( "Ultrasound","US","US RENAL LIMITED RETROPERITONEAL","ABDOMEN" ),
				new Procedure ( "X-Ray","XR","XR LUMBAR SPINE 3 VIEW","LSPINE" ),
				new Procedure ( "Computed Tomography","CT","CTA HEAD WO/W IVCON","NEURO-HEAD" ),
				new Procedure ( "Bone Densitometry","BD","BD BONE DENSITY","BONES" ),
				new Procedure ( "X-Ray","XR","XR WRIST 3V PA/LAT/OBL RT","WRIST" ),
				new Procedure ( "X-Ray","XR","XR WRIST 3V PA/LAT/OBL LT","WRIST" ),
				new Procedure ( "X-Ray","XR","XR KNEE AP/LAT","MSK-KNEE" ),
				new Procedure ( "X-Ray","XR","XR CHEST AP","CHEST" ),
				new Procedure ( "X-Ray","XR","XR C-ARM FLURO > 1HR -NR","UNDEFINED" ),
				new Procedure ( "","","XR CHEST 1V FRONTAL ","CHEST" ),
				new Procedure ( "X-Ray","XR","XR HIP AP/TRUE LAT W PELV LT","HIP" ),
				new Procedure ( "Computed Tomography","CT","CTA CHEST (GATED) W IVCON","CARDIAC" ),
				new Procedure ( "Mammography","MM","DIGIT SCREEN BILAT","BREAST" ),
				new Procedure ( "X-Ray","XR","GI ESOPHAGUS/PHARYNX W VIDEO","ABDOMEN" ),
				new Procedure ( "X-Ray","XR","XR LUMBAR 2V AP/LAT","LSPINE" ),
				new Procedure ( "X-Ray","XR","XR HIP AP/FROG LAT W PELV LT","HIP" ),
				new Procedure ( "X-Ray","XR","XR FOOT 3VIEW RT","FOOT" ),
				new Procedure ( "Computed Tomography","CT","CT ENTEROGRAPHY W IVCON","ABDOMEN-CT BOWEL" ),
				new Procedure ( "X-Ray","XR","XR LUMBAR AP/LAT WEIGHT BEARING","LSPINE" ),
				new Procedure ( "Mammography","MM","MAMMOGRAM DIGITAL DIAGNOSTIC BIL","BREAST" ),
				new Procedure ( "Magnetic Resonance Imaging","MR","MRI ABDOMEN WO/W IVCON","ABDOMEN-MR ABD" ),
				new Procedure ( "","","OR INJ PROC -NR","UNDEFINED" ),
				new Procedure ( "X-Ray","XR","XR FOOT 3VIEW LT","FOOT" ),
				new Procedure ( "Magnetic Resonance Imaging","MR","MRI THORACIC SPINE WO IVCON","NEURO-TSPINE" ),
				new Procedure ( "Ultrasound","US","US GUIDE VASCULAR ACCESS","UNDEFINED" ),
				new Procedure ( "Computed Tomography","CT","CT BRAIN ATTACK WO IVCON","NEURO-NECK" ),
				new Procedure ( "X-Ray","XR","XR KNEE AP/LAT/TUNNEL/MERCHANT","KNEE" ),
				new Procedure ( "Interventional Radiology","IR","OR INJ PROC -NB-NR","UNDEFINED" ),
				new Procedure ( "Computed Tomography","CT","CT ABD/PEL W IVCON","ERAD-ABDOMEN" ),
				new Procedure ( "X-Ray","XR","XR HIP AP/FROG LAT W PELV LT","MSK-HIP" ),
				new Procedure ( "X-Ray","XR","XR FOREARM AP/LAT","FOREARM" ),
				new Procedure ( "Nuclear Medicine","NM","NM PET/CT TUMOR SKULL-THIGH SUBQ","MULTIPLE" ),
				new Procedure ( "Mammography","MM","H XR BILAT SCR DIG MAMM","BREAST" ),
				new Procedure ( "X-Ray","XR","XR FLUORO PROCEDURE-SPINE -NR","SPINE" ),
				new Procedure ( "X-Ray","XR","XR FLUOROSCOPY PAIN -NR","MULTIPLE" ),
				new Procedure ( "X-Ray","XR","XR CERVICAL SPINE 2-3V","CSPINE" ),
				new Procedure ( "Ultrasound","US","US DVT LOWER LT","LEG" ),
				new Procedure ( "X-Ray","XR","XR HUMERUS AP/LAT","ARM" ),
				new Procedure ( "X-Ray","XR","XR FINGERS PA/LAT/OBL","MSK-HAND" ),
				new Procedure ( "X-Ray","XR","XR ELBOW 3VIEW","ELBOW" ),
				new Procedure ( "X-Ray","XR","GI ESOPHAGUS/PHARYNX W SPEECH","ABDOMEN" ),
				new Procedure ( "X-Ray","XR","XR THORACIC AP/LAT/SWIMMERS","TSPINE" ),
				new Procedure ( "Magnetic Resonance Imaging","MR","MRI LIVER WO/W IVCON","ABDOMEN-MR ABD" ),
				new Procedure ( "X-Ray","XR","XR SHOULDER AP/TRU/AXIL/SU","MSK-SHOULDER" ),
				new Procedure ( "Ultrasound","US","US DVT LOWER RT","LEG" ),
				new Procedure ( "X-Ray","XR","XR SHOULDER 2V AP/TRUE AP RT","SHOULDER" ),
				new Procedure ( "X-Ray","XR","XR ACUTE ABD SERIES 2V ABD+CXR","ABDOMEN" ),
				new Procedure ( "Mammography","MM","MAM DIGITAL DIAGNOSTIC BILAT","BREAST" ),
				new Procedure ( "Interventional Radiology","IR","IR MIDLNE INSERT VAS ACC RN-NBNR","EXTREMITYU" ),
				new Procedure ( "Magnetic Resonance Imaging","MR","MRI BRAIN WWO CONTRAST","HEAD" ),
				new Procedure ( "Magnetic Resonance Imaging","MR","MRI SHOULDER WO IVCON RT","MSK-SHOULDER" ),
				new Procedure ( "X-Ray","XR","XR KNEE 2 VIEW","KNEE" ),
				new Procedure ( "X-Ray","XR","XR BONE DENSITY AXIAL SKEL","LSPINE" ),
				new Procedure ( "Magnetic Resonance Imaging","MR","MRI PANC/BIL WO/W IVCON","ABDOMEN-MR PANC" ),
				new Procedure ( "X-Ray","XR","XR LUMBAR SPINE MIN 4VIEWS","SPINE" ),
				new Procedure ( "Magnetic Resonance Imaging","MR","MRI BRAIN WO CONTRAST","HEAD" ),
				new Procedure ( "Ultrasound","US","US BREAST INCL AXILLA LTD","UNDEFINED" ),
				new Procedure ( "Ultrasound","US","US VENOUS DUPLEX EXT BIL","UNDEFINED" ),
				new Procedure ( "Magnetic Resonance Imaging","MR","MRI BRAIN WWO CONTRAST","NEURO-HEAD" ),
				new Procedure ( "","","OTHR OUTSIDE CD DICOM IMPRT-NBNR","UNDEFINED" ),
				new Procedure ( "X-Ray","XR","XR PELVIS","PELVIS" ),
				new Procedure ( "X-Ray","XR","XR ANKLE AP/LAT/OBL RT","ANKLE" ),
				new Procedure ( "X-Ray","XR","XR SHOULDER AP/TRUE AP","MSK-SHOULDER" ),
				new Procedure ( "X-Ray","XR","XR LUMBAR 4V AP/LAT/ FLEX/EXT","LSPINE" ),
				new Procedure ( "Magnetic Resonance Imaging","MR","MRI BREAST WO/W IVCON BIL","BREAST" ),
				new Procedure ( "Interventional Radiology","IR","IR CON SED >=5YR 1ST 15 MIN -NR","UNDEFINED" ),
				new Procedure ( "X-Ray","XR","XR TIBIA FIBULA 2V UNI","LEG" ),
				new Procedure ( "X-Ray","XR","XR KUB/ABD SINGLE VIEW","ABDOMEN" ),
				new Procedure ( "Nuclear Medicine","NM","NM PET/CT TUMOR SKULL-THIGH INIT","MULTIPLE" ),
				new Procedure ( "X-Ray","XR","XR C-ARM FLUORO -NR","MULTIPLE" ),
				new Procedure ( "X-Ray","XR","XR FOOT 3 VIEW MIN","FOOT" ),
				new Procedure ( "X-Ray","XR","XR FLUORO PROCEDURE - THERAPY-NR","MULTIPLE" ),
				new Procedure ( "Nuclear Medicine","NM","NM RIBONE DX MDP/DOSE -NB-NR","UNDEFINED" ),
				new Procedure ( "Magnetic Resonance Imaging","MR","MRI LUMBAR SPINE WWO CONTRAST","ERAD-NEURO" ),
				new Procedure ( "X-Ray","XR","XR SHOULDER 2V AP/TRUE AP LT","SHOULDER" ),
				new Procedure ( "Interventional Radiology","IR","IR CENTRAL LINE REMOVAL","CHEST" ),
				new Procedure ( "X-Ray","XR","XR ANKLE AP/LAT/OBL LT","ANKLE" ),
				new Procedure ( "Ultrasound","US","US PELVIS NON-OB COMPLT","PELVIS" ),
				new Procedure ( "Interventional Radiology","IR","IR FLUORO GUID FOR VEIN DVCE","CHEST" ),
				new Procedure ( "X-Ray","XR","XR HIPS AP/FROG LAT W PELV BIL","MSK-HIP" ),
				new Procedure ( "Magnetic Resonance Imaging","MR","MRI BRAIN WO CONTRAST","ERAD-HEAD" ),
				new Procedure ( "Computed Tomography","CT","CTA C/A/P (GATED) W IVCON","CARDIAC" ),
				new Procedure ( "Computed Tomography","CT","CTA C/A/P (NONGATED) WO/W IVCON","CARDIAC" ),
				new Procedure ( "X-Ray","XR","XR ABDOMEN KUB W/DECUBITUS","ABDOMEN" ),
				new Procedure ( "Computed Tomography","CT","CT LUMBAR SPINE WO IVCON","NEURO-NECK" ),
				new Procedure ( "Computed Tomography","CT","CT CERVICAL SPINE WO IVCON","NEURO-CSPINE" ),
				new Procedure ( "X-Ray","XR","XR HIPS AP/FROG LAT W PELV BIL","HIP" ),
				new Procedure ( "Magnetic Resonance Imaging","MR","MRI CERVICAL SPINE WO IVCON","ERAD-NEURO" ),
				new Procedure ( "Computed Tomography","CT","CT CHEST CARDIAC WO CONTRAST","CARDIAC" ),
				new Procedure ( "Mammography","MM","MAM TOMO ONLY UNI -NB","BREAST" ),
				new Procedure ( "Magnetic Resonance Imaging","MR","MRI LUMBAR SPINE WO CONTRAST","LSPINE" ),
				new Procedure ( "X-Ray","XR","XR LUMBAR AP/LAT/L5S1 FLEX/EXT","SPINE" ),
				new Procedure ( "X-Ray","XR","XR ELBOW 3VIEW","MSK-ELBOW" ),
				new Procedure ( "Computed Tomography","CT","CT FLANK WO IVCON","ABDOMEN-CT AP" ),
				new Procedure ( "X-Ray","XR","XR KNEE AP/LAT UNI","KNEE" ),
				new Procedure ( "X-Ray","XR","XR FLUORO PROCEDURE - SPINE -NR","SPINE" ),
				new Procedure ( "X-Ray","XR","XR HAND PA/LAT/OBL RT","HAND" ),
				new Procedure ( "Mammography","MM","MAMMOGRAM DIGITAL DIAGNOSTIC RT","BREAST" ),
				new Procedure ( "Mammography","MM","MAMMOGRAM DIGITAL DIAGNOSTIC LT","BREAST" ),
				new Procedure ( "X-Ray","XR","XR FEMUR AP/LAT RT","FEMUR" ),
				new Procedure ( "Computed Tomography","CT","CT FACIAL BONE MAND WO IVCON","NEURO-FBONE" ),
				new Procedure ( "X-Ray","XR","XR LUMBAR AP/LAT WEIGHT BEARING","SPINE" ),
				new Procedure ( "Ultrasound","US","US VENOUS DUPLEX EXT UNI","LEG" ),
				new Procedure ( "Magnetic Resonance Imaging","MR","MRI BRAIN WO/W IVCON","ERAD-HEAD" ),
				new Procedure ( "X-Ray","XR","XR FLUORO GUIDE NDL PLCMT-NB-NR","UNDEFINED" ),
				new Procedure ( "Computed Tomography","CT","CT ABDOMEN W IVCON","ABDOMEN-CT ABD" ),
				new Procedure ( "X-Ray","XR","XR KNEE 3V AP/LAT/MERCHANT RT","KNEE" ),
				new Procedure ( "Computed Tomography","CT","CT CHEST WO CONTRAST NODULE F/U","CHEST" ),
				new Procedure ( "Ultrasound","US","US VL CAROTID DUPLEX","NECK" ),
				new Procedure ( "X-Ray","XR","XR THORACIC 3V AP/LAT/SWIMMERS","TSPINE" ),
				new Procedure ( "X-Ray","XR","XR CERVICAL  2V AP/LAT","CSPINE" ),
				new Procedure ( "X-Ray","XR","XR DIGIT 3V FRONTAL/LAT/OBL LT","HAND" ),
				new Procedure ( "X-Ray","XR","XR DIGIT 3V FRONTAL/LAT/OBL RT","HAND" ),
				new Procedure ( "Ultrasound","US","US BREAST INCL AXILLA LTD","BREAST" ),
				new Procedure ( "Magnetic Resonance Imaging","MR","MRI SHOULDER WO IVCON LT","MSK-SHOULDER" ),
				new Procedure ( "X-Ray","XR","XR KNEE AP/LAT/OBL","KNEE" ),
				new Procedure ( "Mammography","MM","MAMMOGRAM CAD SCREEN -NR-NB","BREAST" ),
				new Procedure ( "X-Ray","XR","OR SPNE LUMBSAC 2 OR 3 VWS","LSPINE" ),
				new Procedure ( "Mammography","MM","MAMM DIGITAL SCREENING BILAT","BREAST" ),
				new Procedure ( "Ultrasound","US","US DOPPLER LTD","UNDEFINED" ),
				new Procedure ( "Magnetic Resonance Imaging","MR","MRI 3D RECONSTRUCTION","ABDOMEN-UNDEF" ),
				new Procedure ( "X-Ray","XR","XR THORACIC SPINE 3V","TSPINE" ),
				new Procedure ( "X-Ray","XR","XR CERVICAL 2 OR 3 VIEWS","SPINE" ),
				new Procedure ( "X-Ray","XR","XR TIBIA FIBULA AP/LAT","MSK-LEG" ),
				new Procedure ( "Magnetic Resonance Imaging","MR","MRI ANKLE WO CONTRAST","ERAD-ANKLE" ),
				new Procedure ( "Ultrasound","US","US DOPPLER COMPLETE","UNDEFINED" ),
				new Procedure ( "Ultrasound","US","US SCROTUM AND CONTENTS","MALE_GENITAL" ),
				new Procedure ( "X-Ray","XR","XR FLUORO PROCEDURE SPINE -NB-NR","UNDEFINED" ),
				new Procedure ( "X-Ray","XR","XR WRIST 3VIEW /SCAPHOID","MSK-WRIST" ),
				new Procedure ( "Ultrasound","US","US EXTREM SOFT TISSUE LTD","MULTIPLE" ),
				new Procedure ( "Ultrasound","US","US PELVIS NON-OB","PELVIS" ),
				new Procedure ( "Bone Densitometry","BD","BMD BONE DENSITY","BONES" ),
				new Procedure ( "X-Ray","XR","XR KNEE 3 VIEWS LT","KNEE" ),
				new Procedure ( "X-Ray","XR","XR LUMBAR AP/LAT/L5S1","SPINE" ),
				new Procedure ( "Ultrasound","US","US CAROTID BIL","NECK" ),
				new Procedure ( "Magnetic Resonance Imaging","MR","MRI BRAIN WO CONTRAST","NEURO-HEAD" ),
				new Procedure ( "X-Ray","XR","XR KNEE 3V AP/LAT/MERCHANT LT","KNEE" )
			};
		}
	}
}
