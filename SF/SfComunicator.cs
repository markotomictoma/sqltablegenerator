using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF
{
    public class SfComunicator
    {
        //private const string url = "https://login.salesforce.com/services/Soap/u/36.0";//u for partner api, c for enterprise
        //private const string username = "tomic.84@gmail.com";
        //private const string password = "t1o2m3i4c5";
        //private const string securityToken = "27hPuoGOk2QpmF7GoDGYAGUq";
        private const string url = "https://test.salesforce.com/services/Soap/u/36.0";//u for partner api, c for enterprise
        private const string username = "extern.tomic_marko@allianz.de.test";
        private const string password = "t1o2m3i4c5";
        private const string securityToken = "Ne543k2khdyTGnB22hphbSsN";
        private SF.SforceService service;

        public void Login()
        {
            service = new SF.SforceService();
            service.Url = url;
            SF.LoginResult lr = service.login(username, password + securityToken);
            service.Url = lr.serverUrl;
            service.SessionHeaderValue = new SF.SessionHeader();
            service.SessionHeaderValue.sessionId = lr.sessionId;
        }

        public SF.DescribeSObjectResult[] GetAllObjects()
        {
            SF.DescribeGlobalResult dgr = service.describeGlobal();
            SF.DescribeGlobalSObjectResult[] dgsor = dgr.sobjects;
            List<String> objNames = new List<String>();
            foreach (SF.DescribeGlobalSObjectResult res in dgsor)
            {
                if (ObjectList.ShouldBeCreated(res))
                {
                    objNames.Add(res.name);
                }
            }
            List<List<String>> lObjNames = new List<List<String>>();
            int cnt = 0;
            if(objNames.Count > 100)
            {
                for(int i = 0; i < objNames.Count; i++)
                {
                    if(i == 0 || i % 100 == 0)
                    {
                        lObjNames.Add(new List<String>());
                    }
                    if(i != 0 && i % 100 == 0)
                    {
                        cnt++;
                    }
                    lObjNames[cnt].Add(objNames[i]);
                }
            }else
            {
                lObjNames.Add(objNames);
            }
            List<SF.DescribeSObjectResult[]> lObjs = new List<SF.DescribeSObjectResult[]>();
            foreach (List<String> _objNames in lObjNames)
            {
                lObjs.Add(service.describeSObjects(_objNames.ToArray()));
            }
            SF.DescribeSObjectResult[] objs = new SF.DescribeSObjectResult[objNames.Count];
            cnt = 0;
            foreach(SF.DescribeSObjectResult[] ldsor in lObjs)
            {
                for(int i = 0; i < ldsor.Length; i++)
                {
                    objs[cnt] = ldsor[i];
                    cnt++;
                }
            }
            return objs;
        }
    }
}
