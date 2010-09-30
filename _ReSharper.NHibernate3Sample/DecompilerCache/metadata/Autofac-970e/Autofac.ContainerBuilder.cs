// Type: Autofac.ContainerBuilder
// Assembly: Autofac, Version=2.3.1.530, Culture=neutral, PublicKeyToken=17863af14b0044da
// Assembly location: D:\Learning\NHibernate3\NHibernate3Sample\Libs\Autofac\Library\Autofac.dll

using Autofac.Core;
using System;

namespace Autofac
{
    public class ContainerBuilder
    {
        public virtual void RegisterCallback(Action<IComponentRegistry> configurationCallback);
        public IContainer Build();
        public void Update(IContainer container);
        public void Update(IComponentRegistry componentRegistry);
    }
}
