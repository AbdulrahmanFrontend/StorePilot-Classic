using StorePilot.Application.Dtos.PaymentMethodDtos;
using StorePilot.Domain.Entities;

namespace StorePilot.Application.Mappings;

public static class MappingPaymentMethod
{
    public static PaymentMethodDto ToDto(this PaymentMethod paymentMethod)
        => new PaymentMethodDto(paymentMethod.MethodId, paymentMethod.Name);
}
