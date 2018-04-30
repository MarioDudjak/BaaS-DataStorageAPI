using DataStorage.Repository.Common;
using DataStorage.Service.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStorage.Service
{
    public class SchemaService: ISchemaService
    {
        #region Properties

        protected ISchemaRepository SchemaRepository { get; private set; }

        #endregion Properties

        #region Constructors

        public SchemaService(ISchemaRepository resourceRepository)
        {
            SchemaRepository = resourceRepository;
        }

        #endregion Constructors

        #region Methods

        #endregion Methods
    }
}
