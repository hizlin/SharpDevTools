namespace VsTidy.Core.Models
{
    public class Payload : JsonBase
    {
        public string fileName { get; set; }
        public string sha256 { get; set; }
        public int size { get; set; }
        public string url { get; set; }

        public bool isDynamicEndpoint { get; set; }
        public bool cache { get; set; }

        /* 引用 JsonCatalog.signers 资源
         * "signer": {
         *     "$ref": "{id}"
         * }
         */
        public object signer { get; set; }
    }

}
