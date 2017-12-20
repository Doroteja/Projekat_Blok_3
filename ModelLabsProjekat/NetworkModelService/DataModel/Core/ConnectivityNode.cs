using FTN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Core
{
    public class ConnectivityNode : IdentifiedObject
    {
        private string description;
        private long connectivityNodeContainer = 0;
        private List<long> terminals = new List<long>();

        public ConnectivityNode(long globalId) : base(globalId)
        {
        }

        public long ConnectivityNodeContainer
        {
            get
            {
                return connectivityNodeContainer;
            }

            set
            {
                connectivityNodeContainer = value;
            }
        }

        public List<long> Terminals
        {
            get
            {
                return terminals;
            }

            set
            {
                terminals = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                ConnectivityNode x = (ConnectivityNode)obj;
                return ((x.connectivityNodeContainer == this.connectivityNodeContainer) && CompareHelper.CompareLists(x.terminals, this.terminals));
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
                case ModelCode.CONNECTIVITYNODE_DESCRIPTION:
                case ModelCode.CONNECTIVITYNODE_CONNNODECONTAINER:
                case ModelCode.CONNECTIVITYNODE_TERMINALS:
                    return true;

                default:
                    return base.HasProperty(t);

            }
        }

        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.CONNECTIVITYNODE_DESCRIPTION:
                    property.SetValue(description);
                    break;

                case ModelCode.CONNECTIVITYNODE_CONNNODECONTAINER:
                    property.SetValue(connectivityNodeContainer);
                    break;

                case ModelCode.CONNECTIVITYNODE_TERMINALS:
                    property.SetValue(terminals);
                    break;

                default:
                    base.GetProperty(property);
                    break;
            }
        }

        public override void SetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.CONNECTIVITYNODE_DESCRIPTION:
                    description = property.AsString();
                    break;

                case ModelCode.CONNECTIVITYNODE_CONNNODECONTAINER:
                    connectivityNodeContainer = property.AsReference();
                    break;
                    
                default:
                    base.SetProperty(property);
                    break;
            }
        }

        #endregion IAccess implementation



        #region IReference implementation

        public override bool IsReferenced
        {
            get
            {
                return terminals.Count != 0 || base.IsReferenced;
            }
        }

        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            if (connectivityNodeContainer != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both))
            {
                references[ModelCode.CONNECTIVITYNODE_CONNNODECONTAINER] = new List<long>();
                references[ModelCode.CONNECTIVITYNODE_CONNNODECONTAINER].Add(connectivityNodeContainer);
            }

            if (terminals != null && terminals.Count != 0 && (refType == TypeOfReference.Target || refType == TypeOfReference.Both))
            {
                references[ModelCode.CONNECTIVITYNODE_TERMINALS] = terminals.GetRange(0, terminals.Count);
            }

            base.GetReferences(references, refType);
        }

        public override void AddReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.TERMINAL_CONNECTIVITYNODE:
                    terminals.Add(globalId);
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
                case ModelCode.TERMINAL_CONNECTIVITYNODE:

                    if (terminals.Contains(globalId))
                    {
                        terminals.Remove(globalId);
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
