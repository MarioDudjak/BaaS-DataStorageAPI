using DataStorage.Repository.Common;
using DataStorage.Service.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStorage.Service
{
    public class ResourceService: IResourceService
    {
        #region Properties

        protected IResourceRepository ResourceRepository { get; private set; }

        #endregion Properties

        #region Constructors

        public ResourceService(IResourceRepository resourceRepository)
        {
            ResourceRepository = resourceRepository;
        }

        #endregion Constructors

        #region Methods

        #endregion Methods
    }
}
