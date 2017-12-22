using FTN.Common;
using FTN.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelventDMS.Services.NetworkModelService.TestClient.Tests;
using System.ServiceModel;

namespace WpfClient.Connection
{
    public class Connection : IDisposable
    {
        private ModelResourcesDesc modelResourceDesc = new ModelResourcesDesc();

        private static Connection instance = null;

        private NetworkModelGDAProxy gdaProxy = null;

        public NetworkModelGDAProxy GdaProxy
        {
            get
            {
                return gdaProxy;
            }

        }

        public static Connection Instance()
        {
           if (instance == null)
           {
                instance = new Connection();
           }
            return instance;
        }

        private Connection()
        {
            gdaProxy = new NetworkModelGDAProxy("NetworkModelGDAEndpoint");
            gdaProxy.Open();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ResourceDescription GetValues(long globalId)
        {
            return null;
        }

        public List<long> GetExtentValues(ModelCode modelCode, List<ModelCode> properties)
        {
            int iteratorId = 0;
            List<long> ids = new List<long>();

            try
            {
                int numberOfResources = 2;
                int resourcesLeft = 0;

                iteratorId = GdaProxy.GetExtentValues(modelCode, properties);
                resourcesLeft = GdaProxy.IteratorResourcesLeft(iteratorId);

                while (resourcesLeft > 0)
                {
                    List<ResourceDescription> rds = GdaProxy.IteratorNext(numberOfResources, iteratorId);

                    for (int i = 0; i < rds.Count; i++)
                    {
                        ids.Add(rds[i].Id);
                    }

                    resourcesLeft = GdaProxy.IteratorResourcesLeft(iteratorId);
                }
                GdaProxy.IteratorClose(iteratorId);

            }
            catch{}
            return ids;
        }

        public List<long> GetRelatedValues(long sourceGlobalId, List<ModelCode> properties, Association association)
        {
            return null;
        }
    }
}
