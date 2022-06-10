namespace VsTidy.Core.Models
{
    public class Signature : JsonBase
    {
        public SignInfo signInfo { get; set; }
        public string signatureValue { get; set; }
        public KeyInfo keyInfo { get; set; }
        public CounterSign counterSign { get; set; }
    }

    public class SignInfo : JsonBase
    {
        public string signatureMethod { get; set; }
        public string digestMethod { get; set; }
        public string digestValue { get; set; }
        public string canonicalization { get; set; }
    }

    public class KeyInfo : JsonBase
    {
        public KeyValue keyValue { get; set; }
        public string[] x509Data { get; set; }
    }

    public class KeyValue : JsonBase
    {
        public RsaKeyValue rsaKeyValue { get; set; }
    }

    public class RsaKeyValue : JsonBase
    {
        public string modulus { get; set; }
        public string exponent { get; set; }
    }

    public class CounterSign : JsonBase
    {
        public string[] x509Data { get; set; }
        public string timestamp { get; set; }
        public string counterSignatureMethod { get; set; }
        public string counterSignature { get; set; }
    }
}
