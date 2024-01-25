using System;

namespace PaymentMicroservice.Core.Utils
{
    public static class EnumHelpers
    {
        public static TEnum ConvertStringToEnum<TEnum>(string input) where TEnum : struct
        {
            if (Enum.TryParse<TEnum>(input, true, out var result))
            {
                if (Enum.IsDefined(typeof(TEnum), result))
                {
                    return result;
                }
            }

            throw new ArgumentException($"Invalid value for {typeof(TEnum).Name}.");
        }
    }
}