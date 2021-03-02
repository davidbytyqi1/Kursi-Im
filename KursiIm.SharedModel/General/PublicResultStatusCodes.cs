using System;
using System.Collections.Generic;
using System.Text;

namespace KursiIm.SharedModel.General
{
    public enum PublicResultStatusCodes
    {
        Done = 0,
        ClientIdNotValid = 1,
        ClientSecertNotValid = 2,
        NotAuthorized = 3,
        InternalServerError = 4,
        ModelIsNotValid = 5,
        QueryHasError = 6,
        AccountAlreadyExists = 7,
        ActiveDirectoryAccountNotExists = 8,
        ExpiredAccount = 9,
        DocumentTypeNotSupported = 10,
        WrongOldPassword = 11,
        NotAllowedOperation = 12,
        RecordExist = 13,
        EntityHasChildren = 14,
        EditOperationWasNotPerformed = 15,
        AnalogousRecordExist = 16,
        EmailSentSuccessfully = 17,
        EmailSentFailed = 18,
    }
}
