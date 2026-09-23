using System;
using System.Collections.Generic;
using System.Text;

namespace StorePilot.Application.Dtos.PaymentMethodDtos;

public sealed record PaymentMethodDto(
    int MethodId,
    string Name);