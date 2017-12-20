﻿using FTN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Core
{
    public class ConnectivityNodeContainer : PowerSystemResource
    {
        private List<long> connectivityNodes = new List<long>();
        public ConnectivityNodeContainer(long globalId) : base(globalId)
        {
        }

        public List<long> ConnectivityNodes
        {
            get
            {
                return connectivityNodes;
            }

            set
            {
                connectivityNodes = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                ConnectivityNodeContainer x = (ConnectivityNodeContainer)obj;
                return ((CompareHelper.CompareLists(x.connectivityNodes, this.connectivityNodes)));
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        #region IAccess implementation

        public override bool HasProperty(ModelCode t)
        {
            switch (t)
            {
                case ModelCode.CONNECTIVITYNODECONTAINER_CONNNODES:
                    return true;

                default:
                    return base.HasProperty(t);
            }
        }

        public override void GetProperty(Property prop)
        {
            switch (prop.Id)
            {
                case ModelCode.CONNECTIVITYNODECONTAINER_CONNNODES:
                    prop.SetValue(connectivityNodes);
                    break;
                default:
                    base.GetProperty(prop);
                    break;

            }
        }

        #endregion IAccess implementation	



        #region IReference implementation

        public override bool IsReferenced
        {
            get
            {
                return connectivityNodes.Count > 0 || base.IsReferenced;
            }
        }

        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            if (connectivityNodes != null && connectivityNodes.Count > 0 && (refType == TypeOfReference.Target || refType == TypeOfReference.Both))
            {
                references[ModelCode.CONNECTIVITYNODECONTAINER_CONNNODES] = connectivityNodes.GetRange(0, connectivityNodes.Count);
            }

            base.GetReferences(references, refType);
        }

        public override void AddReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.CONNECTIVITYNODE_CONNNODECONTAINER:
                    connectivityNodes.Add(globalId);
                    break;

                default:
                    base.AddReference(referenceId, globalId);
                    break;
            }
        }

        public override void RemoveReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.CONNECTIVITYNODE_CONNNODECONTAINER:

                    if (connectivityNodes.Contains(globalId))
                    {
                        connectivityNodes.Remove(globalId);
                    }
                    else
                    {
                        CommonTrace.WriteTrace(CommonTrace.TraceWarning, "Entity (GID = 0x{0:x16}) doesn't contain reference 0x{1:x16}.", this.GlobalId, globalId);
                    }

                    break;

                default:
                    base.RemoveReference(referenceId, globalId);
                    break;
            }
        }

        #endregion IReference implementation	
    }
}
