using FTN.Common;
using FTN.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelventDMS.Services.NetworkModelService.TestClient.Tests;
using System.ServiceModel;
using System.Windows;

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

        public ModelResourcesDesc ModelResourceDesc
        {
            get
            {
                return modelResourceDesc;
            }

            set
            {
                modelResourceDesc = value;
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
            try
            {
                gdaProxy.Open();
            }
            catch
            {
                MessageBox.Show("Service host is not started.");
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ResourceDescription GetValues(long globalId, List<ModelCode> properties)
        {
            ResourceDescription rd = null;

            try
            {
                short modelCode = ModelCodeHelper.ExtractTypeFromGlobalId(globalId);
       
                rd = GdaProxy.GetValues(globalId, properties);
            }
            catch (Exception e)
            {
                MessageBox.Show(String.Format("Getting values method failed. Check service connection. ", globalId));
                return null;
            }

            return rd;
        }

        public List<ResourceDescription> GetExtentValues(ModelCode modelCode, List<ModelCode> properties)
        {
            int iteratorId = 0;
            List<ResourceDescription> retList = new List<ResourceDescription>();

            try
            {
                int numberOfResources = 2;
                int resourcesLeft = 0;

                try
                {
                    iteratorId = GdaProxy.GetExtentValues(modelCode, properties);
                    resourcesLeft = GdaProxy.IteratorResourcesLeft(iteratorId);
                }
                catch (Exception e)
                {
                    MessageBox.Show(String.Format("Getting extent values method failed. Check service connection. ", modelCode));
                }

                while (resourcesLeft > 0)
                {
                    List<ResourceDescription> rds = GdaProxy.IteratorNext(numberOfResources, iteratorId);

                    for (int i = 0; i < rds.Count; i++)
                    {
                        retList.Add(rds[i]);
                    }

                    resourcesLeft = GdaProxy.IteratorResourcesLeft(iteratorId);
                }
                GdaProxy.IteratorClose(iteratorId);

            }
            catch{}
            return retList;
        }

        public List<ResourceDescription> GetRelatedValues(long sourceGlobalId, List<ModelCode> properties, Association association)
        {
            List<ResourceDescription> retVal = new List<ResourceDescription>();
            int numberOfResources = 2;

            try
            {
                int iteratorId = GdaProxy.GetRelatedValues(sourceGlobalId, properties, association);
                int resourcesLeft = GdaProxy.IteratorResourcesLeft(iteratorId);

                while (resourcesLeft > 0)
                {
                    List<ResourceDescription> rds = GdaProxy.IteratorNext(numberOfResources, iteratorId);

                    for (int i = 0; i < rds.Count; i++)
                    {
                        retVal.Add(rds[i]);
                    }

                    resourcesLeft = GdaProxy.IteratorResourcesLeft(iteratorId);

                    GdaProxy.IteratorClose(iteratorId);
                }
            }
            catch
            {
                MessageBox.Show(String.Format("Getting related values method failed. Check service connection. ", sourceGlobalId));
            }

            return retVal;
        }
    }
}
