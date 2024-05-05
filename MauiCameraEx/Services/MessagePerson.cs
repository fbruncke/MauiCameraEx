using CommunityToolkit.Mvvm.Messaging.Messages;
using MauiCameraEx.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiCameraEx.Services
{
    public class MessagePerson : ValueChangedMessage<Person>
    {
        public MessagePerson(Person value) : base(value)
        {
        }
    }
}
