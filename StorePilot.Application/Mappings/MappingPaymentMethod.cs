using StorePilot.Application.Dtos.PaymentMethodDtos;
using StorePilot.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorePilot.Application.Mappings;

public static class MappingPaymentMethod
{
    public static PaymentMethodDto ToDto(this PaymentMethod paymentMethod)
        => new PaymentMethodDto(paymentMethod.MethodId, paymentMethod.Name);
}
