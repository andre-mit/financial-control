﻿using BCrypt.Net;
using Flunt.Validations;
using Flunt.Notifications;
using Flunt.Extensions.Br.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinancialControl.Core.Entities;

namespace FinancialControl.Domain.Entities;

public class User : Entity
{
    private readonly IList<CreditCard> _creditCards;
    private readonly IList<Expense> _expenses;
    
    public string Name { get; private set; }
    public string Email { get; private set; }
    public bool EmailConfirmed { get; private set; }
    public string? Password { get; private set; }
    public string? Phone { get; private set; }
    public bool PhoneConfirmed { get; private set; }
    public IReadOnlyCollection<CreditCard> CreditCards => _creditCards.ToArray();
    public IReadOnlyCollection<Expense> Expenses => _expenses.ToArray();
    public Role? Role { get; private set; }

    public User(string name, string email)
    {
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsNotNullOrWhiteSpace(name, "Nome", "Nome inválido")
            .IsLowerOrEqualsThan(name, 100, "Nome", "Nome deve ter no máximo 100 caracteres")
            .IsEmail(email, "Email", "Email inválido")
        );

        Name = name;
        Email = email;
        _expenses = new List<Expense>();
        _creditCards = new List<CreditCard>();
    }

    public void ChangeEmail(string email)
    {
        AddNotifications(
            new Contract<Notification>()
            .Requires()
            .IsEmail(email, "Email", "Email Inválido")
        );

        EmailConfirmed = false;
        Email = email;
    }

    public void ChangeName(string name)
    {
        AddNotifications(
            new Contract<Notification>()
            .Requires()
            .IsNotNullOrWhiteSpace(name, "Nome", "Nome inválido")
        );
        Name = name;
    }

    public void ConfirmEmail()
    {
        EmailConfirmed = true;
    }

    public void ChangePhone(string phone)
    {
        AddNotifications(
           new Contract<Notification>()
           .Requires()
           .IsPhoneNumber(phone, "Phone", "Telefone Inválido")
        );

        PhoneConfirmed = false;
        Phone = phone;
    }

    public void ConfirmPhone()
    {
        PhoneConfirmed = true;
    }

    public bool VerifyPassword(string password)
    {
        return BCrypt.Net.BCrypt.Verify(password, Password);
    }

    public void ChangePassword(string password)
    {
        AddNotifications(
           new Contract<Notification>()
           .Requires()
           .IsGreaterOrEqualsThan(password.Length, 8, "Password", "Senha Inválido")
           .Matches(password, @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[$*&@#])(?:([0-9a-zA-Z$*&@#])(?!\1)){8,}$", "Password", "Senha não contém caracteres obrigatórios")
        );

        Password = BCrypt.Net.BCrypt.HashPassword(password);
    }

    public void AddExpense(Expense expense)
    {
        if (expense.IsValid)
            _expenses.Add(expense);
    }

    public void AddCreditCard(CreditCard creditCard)
    {
        if (creditCard.IsValid)
            _creditCards.Add(creditCard);
    }
}