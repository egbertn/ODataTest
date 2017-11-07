using Newtonsoft.Json.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace UnitTestProject1
{
    public class NullToEmptyListResolver : DefaultContractResolver
    {
        protected override IValueProvider CreateMemberValueProvider(MemberInfo member)
        {
            var provider = base.CreateMemberValueProvider(member);

            if (member.MemberType == MemberTypes.Property)
            {
                Type propType = ((PropertyInfo)member).PropertyType;
                if (propType.IsArray || (propType.IsGenericType &&
                    propType.GetGenericTypeDefinition().IsAssignableFrom(typeof(IEnumerable<>))))
                {
                    return new EmptyListValueProvider(provider, propType);
                }
            }

            return provider;
        }

        public class EmptyListValueProvider : IValueProvider
        {
            private readonly IValueProvider innerProvider;

            public EmptyListValueProvider(IValueProvider innerProvider, Type listType)
            {
                this.innerProvider = innerProvider;
            }

            public void SetValue(object target, object value)
            {
                throw new NotImplementedException();
            }

            public object GetValue(object target)
            {
                var val = innerProvider.GetValue(target);
                if (val == null) return null;
                var enumerator = (IEnumerable)val;
                // we got an array with zero entries? convert it to null so e.g. "experts: []" becomes "experts": null
                return enumerator.GetEnumerator().MoveNext() == false ? null : val;
            }
        }
    }
}
