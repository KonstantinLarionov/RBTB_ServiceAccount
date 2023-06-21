﻿namespace RBTB_ServiceAccount.Client.Common
{
    public abstract class BaseRequest
    {
        internal abstract string EndPoint { get; }

        internal abstract RequestMethod Method { get; }

        internal virtual IDictionary<string, string> Properties => null;

        public virtual IDictionary<string, string> Headers { get; set; }
    }
}