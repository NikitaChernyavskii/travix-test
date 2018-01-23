using AutoMapper;
using Core.Infrastructure;

namespace Core.Tests
{

    public static class InitializeMappingService
    {
        private static bool _isInitialized = false;
        private static readonly object _lockObj = new object();

        // Automapper must be Initialized only once or we will have exception.
        public static void InitializaAutoMapper()
        {
            if (!_isInitialized)
            {
                lock (_lockObj)
                {
                    if (!_isInitialized)
                    {
                        Mapper.Initialize(config =>
                        {
                            CoreMappingRegisterService.Register(config);
                        });
                        _isInitialized = true;
                    }
                }
            }
        }
    }
}
