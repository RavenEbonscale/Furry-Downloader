using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E621_Wrapper.ApiResponses
{
    class ResponseMessages
    {
        Dictionary<int, string> Status_code
        {
            get
            {
                Dictionary<int, string> dic = new()
                {
                    { 200,"OK"},
                    { 204,"No Content"},
                    { 403,"Forbidden"},
                    { 404,"Not Found" },
                    { 412,"Precondition failed" },
                    {420,"Invalid Record"},
                    { 520,"Unknown Error"},
                    { 525,"SSL Handshake Failed"}

                
                };
                return dic;
            }
        }
    
    }
}
