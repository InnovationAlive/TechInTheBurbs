using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Compute.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechInTheBurbs.Core
{
    public class AzureBridge
    {
        public const string base64EncodedCertificate = "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";
        public const string subscriptionId = "08df64f4-9e16-47ff-9265-f29a371949e7";
        public static CertificateCloudCredentials cloudCredentials = new CertificateCloudCredentials(subscriptionId, new System.Security.Cryptography.X509Certificates.X509Certificate2(Convert.FromBase64String(base64EncodedCertificate)));

        public static List<dynamic> RetrieveVMList()
        {
            ComputeManagementClient client = new ComputeManagementClient(cloudCredentials);
            var hostedServices = client.HostedServices.List();
            
            var lResult = new List<dynamic>();

            foreach (var service in hostedServices)
            {
                var deployment = GetAzureDeployment(service.ServiceName, DeploymentSlot.Production);

                if (deployment != null)
                {
                    if (deployment.Roles.Count > 0)
                    {
                        foreach (var role in deployment.Roles)
                        { 
                            if(role.RoleType == VirtualMachineRoleType.PersistentVMRole.ToString())
                            {
                                dynamic dynObj = new ExpandoObject();
                                dynObj.Name = role.RoleName;
                                dynObj.Status = deployment.Status.ToString();
                                dynObj.StatusCode = deployment.StatusCode.ToString();

                                lResult.Add(dynObj);
                                Console.WriteLine(role.RoleName);
                            }
                        }
                    }
                }
            }
            
            return lResult;
        }

        private static DeploymentGetResponse GetAzureDeployment(string serviceName, DeploymentSlot slot)
        {
            ComputeManagementClient client = new ComputeManagementClient(cloudCredentials);
            
            try
            {
                return client.Deployments.GetBySlot(serviceName, slot);
            }
            catch (CloudException ex)
            {
                if (ex.ErrorCode == "ResourceNotFound")
                {
                    return null;
                }
                else
                {
                    throw ex;
                }
            }
        }

        public static void StartVM(string name)
        {
            ComputeManagementClient client = new ComputeManagementClient(cloudCredentials);
            client.VirtualMachines.Start(name, name, name);
        }

        public static void StopVM(string name)
        {
            ComputeManagementClient client = new ComputeManagementClient(cloudCredentials);
            client.VirtualMachines.Shutdown(name, name, name, new VirtualMachineShutdownParameters() { PostShutdownAction = PostShutdownAction.StoppedDeallocated });
        }

        public static void RestartVM(string name)
        {
            ComputeManagementClient client = new ComputeManagementClient(cloudCredentials);
            client.VirtualMachines.Restart(name, name, name);
        }

        private static void RetrieveVMStatus(string name)
        {
            ComputeManagementClient client = new ComputeManagementClient(cloudCredentials);
            var kaark = client.VirtualMachines.Get("techintheburbs", "techintheburbs", "techintheburbs");
        }
    }
}
