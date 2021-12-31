using FinancialControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FinancialControl.Tests.Domain.Entities;

public class UserTests
{
    [Fact(DisplayName = "Dado um usuário válido o mesmo deve ser válido")]
    public void Dado_usuario_valido_deve_criar()
    {
        var user = new User("André", "contato@andre-mit.dev", null);

        var notifications = user.Notifications.Select(x => $"{x.Key}: {x.Message}").ToList();

        Assert.True(user.IsValid, string.Join(';', notifications));
    }

    [Fact(DisplayName = "Dado usuário com nome inválido o mesmo deve ser inválido")]
    public void Dado_usuario_com_nome_invalido_o_mesmo_deve_ser_inválido()
    {
        var user = new User(string.Empty, "contato@andre-mit.dev", null);

        var notifications = user.Notifications.Select(x => $"{x.Key}: {x.Message}").ToList();

        Assert.False(user.IsValid, string.Join(';', notifications));
    }

    [Fact(DisplayName = "Dado usuário com email inválido, o mesmo deve ser inválido")]
    public void Dado_usuario_com_email_invalido_o_mesmo_deve_ser_invalido()
    {
        var user = new User("André", "contatoandre-mit.dev", null);

        var notifications = user.Notifications.Select(x => $"{x.Key}: {x.Message}").ToList();

        Assert.False(user.IsValid, string.Join(';', notifications));
    }

    [Fact(DisplayName = "Dado usuário com email nulo, o mesmo deve ser inválido")]
    public void Dado_usuario_com_email_nulo_o_mesmo_deve_ser_invalido()
    {
        var user = new User("André", null, null);

        var notifications = user.Notifications.Select(x => $"{x.Key}: {x.Message}").ToList();

        Assert.False(user.IsValid, string.Join(';', notifications));
    }

    [Fact(DisplayName = "Dado usuário com telefone inválido, o mesmo deve ser inválido")]
    public void Dado_usuario_com_telefone_invalido_o_mesmo_deve_ser_invalido()
    {
        Assert.True(false, "Not Implemented");
    }

    [Fact(DisplayName = "Dado usuário com telefone nulo, o mesmo deve ser inválido")]
    public void Dado_usuario_com_telefone_nulo_o_mesmo_deve_ser_invalido()
    {
        Assert.True(false, "Not Implemented");
    }
}