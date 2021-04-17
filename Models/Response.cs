using System.Collections.Generic;

namespace Primeira_api.Models
{
    public class Response
    {
        private string _message = "";
        private string _campo = "";
        private string _errorType = "";
        private List<object> _responseList = new List<object>();

        public void SetResponse(string message)
        {
            this._message = message;
        }

        public void SetResponse(string message, string campo)
        {
            this._message = message;
            this._campo = campo;
        }

        public void SetResponse(string message, string campo, string errorType)
        {
            this._message = message;
            this._campo = campo;
            this._errorType = errorType;
        }

        public List<object> GetResponse()
        {
            if (_errorType.Length != 0)
            {
                this._responseList.Add(new { message = this._message, campo = this._campo });
            }
            else
            {
                this._responseList.Add(new { errorType = this._errorType, message = this._message, campo = this._campo });
            }

            return this._responseList;
        }
    }
}