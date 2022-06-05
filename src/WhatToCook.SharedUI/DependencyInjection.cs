using Microsoft.Extensions.DependencyInjection;

namespace WhatToCook.SharedUI
{
    public static class DependencyInjection
    {
        public static IServiceCollection UseSharedUI(this IServiceCollection services)
        {
            services.AddLocalization();
            return services;
        }
    }
}
