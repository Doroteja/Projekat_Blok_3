namespace FTN.ESI.SIMES.CIM.CIMAdapter.Importer
{
	using FTN.Common;

	/// <summary>
	/// PowerTransformerConverter has methods for populating
	/// ResourceDescription objects using PowerTransformerCIMProfile_Labs objects.
	/// </summary>
	public static class PowerTransformerConverter
	{
        // Fill in all properties
		#region Populate ResourceDescription

		public static void PopulateIdentifiedObjectProperties(FTN.IdentifiedObject cimIdentifiedObject, ResourceDescription rd)
		{
			if ((cimIdentifiedObject != null) && (rd != null))
			{
				if (cimIdentifiedObject.MRIDHasValue)
				{
					rd.AddProperty(new Property(ModelCode.IDOBJ_MRID, cimIdentifiedObject.MRID));
				}
                if (cimIdentifiedObject.NameHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.IDOBJ_NAME, cimIdentifiedObject.Name));
                }
                if (cimIdentifiedObject.AliasNameHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.IDOBJ_ALIASNAME, cimIdentifiedObject.AliasName));
                }
            }
		}
        
		public static void PopulatePowerSystemResourceProperties(FTN.PowerSystemResource cimPowerSystemResource, ResourceDescription rd)
		{
			if ((cimPowerSystemResource != null) && (rd != null))
			{
				PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimPowerSystemResource, rd);
			}
		}
        
        public static void PopulateSeriesCompensatorProperties(FTN.SeriesCompensator cimSeriesCompensator, ResourceDescription rd)
        {
            if ((cimSeriesCompensator != null) && (rd != null))
            {
                //popuni propertije prethodne klase
                PowerTransformerConverter.PopulateConductingEquipmentProperties(cimSeriesCompensator, rd);
                
                if (cimSeriesCompensator.RHasValue) //1.
                {
                    rd.AddProperty(new Property(ModelCode.SERIESCOMPENSATOR_R, cimSeriesCompensator.R));
                }
                if (cimSeriesCompensator.R0HasValue) //2.
                {
                    rd.AddProperty(new Property(ModelCode.SERIESCOMPENSATOR_R0, cimSeriesCompensator.R0));
                }
                if (cimSeriesCompensator.XHasValue) //3.
                {
                    rd.AddProperty(new Property(ModelCode.SERIESCOMPENSATOR_X, cimSeriesCompensator.X));
                }
                if (cimSeriesCompensator.X0HasValue) //4.
                {
                    rd.AddProperty(new Property(ModelCode.SERIESCOMPENSATOR_X0, cimSeriesCompensator.X0));
                }
            }
        }

        public static void PopulateACLineSegmentProperties(FTN.ACLineSegment cimACLineSegment, ResourceDescription rd)
        {
            if ((cimACLineSegment != null) && (rd != null))
            {
                //popuni propertije prethodne klase
                PowerTransformerConverter.PopulateConductorProperties(cimACLineSegment, rd);

                if (cimACLineSegment.B0chHasValue) //1.
                {
                    rd.AddProperty(new Property(ModelCode.ACLINESEGMENT_B0CH, cimACLineSegment.B0ch));
                }
                if (cimACLineSegment.BchHasValue) //2.
                {
                    rd.AddProperty(new Property(ModelCode.ACLINESEGMENT_BCH, cimACLineSegment.Bch));
                }
                if (cimACLineSegment.G0chHasValue) //3.
                {
                    rd.AddProperty(new Property(ModelCode.ACLINESEGMENT_G0CH, cimACLineSegment.G0ch));
                }
                if (cimACLineSegment.GchHasValue) //4.
                {
                    rd.AddProperty(new Property(ModelCode.ACLINESEGMENT_GCH, cimACLineSegment.Gch));
                }
                if (cimACLineSegment.RHasValue) //5.
                {
                    rd.AddProperty(new Property(ModelCode.ACLINESEGMENT_R, cimACLineSegment.R));
                }
                if (cimACLineSegment.R0HasValue) //6.
                {
                    rd.AddProperty(new Property(ModelCode.ACLINESEGMENT_R0, cimACLineSegment.R0));
                }
                if (cimACLineSegment.XHasValue) //7.
                {
                    rd.AddProperty(new Property(ModelCode.ACLINESEGMENT_X, cimACLineSegment.X));
                }
                if (cimACLineSegment.X0HasValue) //8.
                {
                    rd.AddProperty(new Property(ModelCode.ACLINESEGMENT_X0, cimACLineSegment.X0));
                }
            }
        }

        public static void PopulateDCLineSegmentProperties(FTN.DCLineSegment cimDCLineSegment, ResourceDescription rd)
        {
            if ((cimDCLineSegment != null) && (rd != null))
            {
                //popuni propertije prethodne klase
                PowerTransformerConverter.PopulateConductorProperties(cimDCLineSegment, rd);
            }
        }

        public static void PopulateConnectivityNodeContainerProperties(FTN.ConnectivityNodeContainer cimConnectivityNodeContainer, ResourceDescription rd)
        {
            if ((cimConnectivityNodeContainer != null) && (rd != null))
            {
                //popuni propertije prethodne klase
                PowerTransformerConverter.PopulatePowerSystemResourceProperties(cimConnectivityNodeContainer, rd);
            }
        }

        public static void PopulateConnectivityNodeProperties(FTN.ConnectivityNode cimConnectivityNode, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimConnectivityNode != null) && (rd != null))
            {
                //popuni propertije prethodne klase
                PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimConnectivityNode, rd);

                if (cimConnectivityNode.DescriptionHasValue) //1.
                {
                    rd.AddProperty(new Property(ModelCode.CONNECTIVITYNODE_DESCRIPTION, cimConnectivityNode.Description));
                }

                if (cimConnectivityNode.ConnectivityNodeContainerHasValue) //2.
                {
                    long gid = importHelper.GetMappedGID(cimConnectivityNode.ConnectivityNodeContainer.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").Append(cimConnectivityNode.GetType().ToString()).Append(" rdfID = \"").Append(cimConnectivityNode.ID);
                        report.Report.Append("\" - Failed to set reference to ConnectivityNodeContainer: rdfID \"").Append(cimConnectivityNode.ConnectivityNodeContainer.ID).AppendLine(" \" is not mapped to GID!");
                    }
                    rd.AddProperty(new Property(ModelCode.CONNECTIVITYNODE_CONNNODECONTAINER, gid));
                }

            }
        }

        public static void PopulateTerminalProperties(FTN.Terminal cimTerminal, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimTerminal != null) && (rd != null))
            {
                //popuni propertije prethodne klase
                PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimTerminal, rd);

                if (cimTerminal.ConnectivityNodeHasValue) //1.
                {
                    long gid = importHelper.GetMappedGID(cimTerminal.ConnectivityNode.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").Append(cimTerminal.GetType().ToString()).Append(" rdfID = \"").Append(cimTerminal.ID);
                        report.Report.Append("\" - Failed to set reference to ConnectivityNode: rdfID \"").Append(cimTerminal.ConnectivityNode.ID).AppendLine(" \" is not mapped to GID!");
                    }
                    rd.AddProperty(new Property(ModelCode.TERMINAL_CONNECTIVITYNODE, gid));
                }

                if (cimTerminal.ConductingEquipmentHasValue) //2.
                {
                    long gid = importHelper.GetMappedGID(cimTerminal.ConductingEquipment.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").Append(cimTerminal.GetType().ToString()).Append(" rdfID = \"").Append(cimTerminal.ID);
                        report.Report.Append("\" - Failed to set reference to ConductingEquipment: rdfID \"").Append(cimTerminal.ConductingEquipment.ID).AppendLine(" \" is not mapped to GID!");
                    }
                    rd.AddProperty(new Property(ModelCode.TERMINAL_CONDUCTINGEQUIPMENT, gid));
                }

            }
        }

        public static void PopulateConductorProperties(FTN.Conductor cimConductor, ResourceDescription rd)
        {
            if ((cimConductor != null) && (rd != null))
            {
                //popuni propertije prethodne klase
                PowerTransformerConverter.PopulateConductingEquipmentProperties(cimConductor, rd);

                if (cimConductor.LengthHasValue) //1.
                {
                    rd.AddProperty(new Property(ModelCode.CONDUCTOR_LENGTH, cimConductor.Length));
                }
            }
        }

        public static void PopulateConductingEquipmentProperties(FTN.ConductingEquipment cimConductingEquipment, ResourceDescription rd)
        {
            if ((cimConductingEquipment != null) && (rd != null))
            {
                //popuni propertije prethodne klase
                PowerTransformerConverter.PopulateEquipmentProperties(cimConductingEquipment, rd); 
            }
        }

        public static void PopulateEquipmentProperties(FTN.Equipment cimEquipment, ResourceDescription rd)
		{
			if ((cimEquipment != null) && (rd != null))
			{
				PowerTransformerConverter.PopulatePowerSystemResourceProperties(cimEquipment, rd);
			}
		}

		#endregion Populate ResourceDescription

		#region Enums convert
				
		#endregion Enums convert
	}
}
