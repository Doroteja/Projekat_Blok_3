using System;
using System.Collections.Generic;
using System.Text;

namespace FTN.Common
{
	
	public enum DMSType : short
	{		
		MASK_TYPE							= unchecked((short)0xFFFF),

        SERIESCOMPENSATOR                   = 0x0001,
        ACLINESEGMENT                       = 0x0002,
        DCLINESEGMENT                       = 0x0003,
        CONNECTIVITYNODECONTAINER           = 0x0004,
        CONNECTIVITYNODE                    = 0x0005,
        TERMINAL                            = 0x0006,
    }

    [Flags]
	public enum ModelCode : long
	{
		IDOBJ								= 0x1000000000000000,
		IDOBJ_GID							= 0x1000000000000104,
		IDOBJ_ALIASNAME					    = 0x1000000000000207,
		IDOBJ_MRID							= 0x1000000000000307,
		IDOBJ_NAME							= 0x1000000000000407,

        TERMINAL                            = 0x1100000000060000,
        TERMINAL_CONNECTIVITYNODE           = 0x1100000000060109,
        TERMINAL_CONDUCTINGEQUIPMENT        = 0X1100000000060209,

        CONNECTIVITYNODE                    = 0x1200000000050000,
        CONNECTIVITYNODE_DESCRIPTION        = 0x1200000000050107,
        CONNECTIVITYNODE_CONNNODECONTAINER  = 0x1200000000050209,
        CONNECTIVITYNODE_TERMINALS          = 0x1200000000050319,

        POWERSYSTEMRESOURCE                 = 0x1300000000000000,

        CONNECTIVITYNODECONTAINER           = 0x1310000000040000,
        CONNECTIVITYNODECONTAINER_CONNNODES = 0x1310000000040119,

        EQUIPMENT                           = 0x1320000000000000,

        CONDUCTINGEQUIPMENT                 = 0x1321000000000000,
        CONDUCTINGEQUIPMENT_TERMINALS       = 0x1321000000000119,

        CONDUCTOR                           = 0x1321100000000000,
        CONDUCTOR_LENGTH                    = 0x1321100000000105,

        SERIESCOMPENSATOR                   = 0x1321200000010000,
        SERIESCOMPENSATOR_R                 = 0x1321200000010105,
        SERIESCOMPENSATOR_R0                = 0x1321200000010205,
        SERIESCOMPENSATOR_X                 = 0x1321200000010305,
        SERIESCOMPENSATOR_X0                = 0x1321200000010405,

        DCLINESEGMENT                       = 0x1321110000030000,

        ACLINESEGMENT                       = 0x1321120000020000,
        ACLINESEGMENT_B0CH                  = 0x1321120000020105,
        ACLINESEGMENT_BCH                   = 0x1321120000020205,
        ACLINESEGMENT_G0CH                  = 0x1321120000020305,
        ACLINESEGMENT_GCH                   = 0x1321120000020405,
        ACLINESEGMENT_R                     = 0x1321120000020505,
        ACLINESEGMENT_R0                    = 0x1321120000020605,
        ACLINESEGMENT_X                     = 0x1321120000020705,
        ACLINESEGMENT_X0                    = 0x1321120000020805,
    }

    [Flags]
	public enum ModelCodeMask : long
	{
		MASK_TYPE			 = 0x00000000ffff0000,
		MASK_ATTRIBUTE_INDEX = 0x000000000000ff00,
		MASK_ATTRIBUTE_TYPE	 = 0x00000000000000ff,

		MASK_INHERITANCE_ONLY = unchecked((long)0xffffffff00000000),
		MASK_FIRSTNBL		  = unchecked((long)0xf000000000000000),
		MASK_DELFROMNBL8	  = unchecked((long)0xfffffff000000000),		
	}																		
}


