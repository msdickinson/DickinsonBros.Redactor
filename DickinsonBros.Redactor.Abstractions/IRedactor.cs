using System;

namespace DickinsonBros.Redactor.Abstractions
{
    public interface IRedactorService
    {
        string Redact(object value);
        string Redact(string json);
    }
}
