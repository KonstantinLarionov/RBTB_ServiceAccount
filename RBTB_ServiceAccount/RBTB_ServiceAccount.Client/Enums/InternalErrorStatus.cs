using System.Runtime.Serialization;

namespace Derzhava.Id.Common.Components.Enums
{
    public enum InternalErrorStatus
    {
        #region [Common]
        [EnumMember(Value = "Произошла неизвестная ошибка")] UnknownError = 1,
        [EnumMember(Value = "Авторизация сервиса с использованием client-id, client-secret не удалась")] ClientAuthentificationFailed = 5,
        [EnumMember(Value = "Нет прав для выполнения данного действия")] NoPermissionsForThisAction = 7,
        [EnumMember(Value = "Слишком много однотипных действий")] TooManySimilarActions = 9,
        [EnumMember(Value = "Произошла внутренняя ошибка сервера. Попробуйте повторить запрос позже")] InternalServerError = 10,
        [EnumMember(Value = "Таймаут внутрисерверного запроса")] InternalRequestTimeout = 11,
        [EnumMember(Value = "Передаваемая строка не соответствует Base64 формату")] InvalidBase64String = 20,
        [EnumMember(Value = "Передаваемый идентификатор не соответствует Guid типу")] InvalidGuidIdentifier = 21,
        [EnumMember(Value = "Невалидный Email")] InvalidEmail = 22,
        [EnumMember(Value = "Невалидный номер телефона")] InvalidPhone = 23,
        [EnumMember(Value = "Невалидный файл")] InvalidFile = 24,
        [EnumMember(Value = "Невалидный пароль")] InvalidPassword = 25,
        [EnumMember(Value = "Невалидный ИНН ФЛ")] InvalidPhysicalPersonInn = 26,
        [EnumMember(Value = "Ссылка на файл устарела")] FileLinkExpired = 27,
        #endregion
        #region[Derzhava.Id.Auth]
        [EnumMember(Value = "Лишняя попытка получить Email код")] ExtraAttemptToGetEmailCode = 1001,
        [EnumMember(Value = "Не удалось увеличить счётчик попыток отправки смс-кода")] IncrementLogInByPhoneAttemptsFailed = 1002,
        [EnumMember(Value = "Email код неверный либо недействительный")] EmailCodeInvalidOrExpired = 1003,
        [EnumMember(Value = "Лишняя попытка получить SMS код")] ExtraAttemptToGetSmsCode = 1004,
        [EnumMember(Value = "Не удалось увеличить счётчик попыток отправки Email-кода")] IncrementLogInByEmailAttemptsFailed = 1005,
        [EnumMember(Value = "SMS код неверный либо недействительный")] SmsCodeWrongOrExpired = 1008,
        [EnumMember(Value = "Состояние саги не соответствует запросу")] AuthSagaInWrongPendingState = 1009,
        [EnumMember(Value = "Не удалось выполнить запрос ФЛ по отпечатку сертификата")] GetPhysicalPersonByCrtThumbprintFailed = 1030,
        [EnumMember(Value = "Не удалось выполнить запрос ФЛ по СНИЛС")] GetPhysicalPersonBySnilsFailed = 1031,
        [EnumMember(Value = "Не удалось выполнить запрос ФЛ по ИНН")] GetPhysicalPersonByInnFailed = 1032,
        [EnumMember(Value = "Не удалось выполнить запрос привязки ЭП к ФЛ")] AttachDigitalSignatureToPhysicalPersonFailed = 1033,
        [EnumMember(Value = "Не удалось выполнить запрос создания ФЛ по ЭП")] CreatePhysicalPersonByDigitalSignatureFailed = 1034,
        [EnumMember(Value = "Не удалось выполнить запрос ФЛ по номеру телефона")] GetPhysicalPersonByPhoneFailed = 1036,
        [EnumMember(Value = "Не удалось выполнить запрос ФЛ по Email")] GetPhysicalPersonByEmailFailed = 1037,
        [EnumMember(Value = "Не удалось выполнить запрос ФЛ по Email и паролю")] GetPhysicalPersonByEmailAndPasswordFailed = 1038,
        [EnumMember(Value = "Не удалось распарсить ЭП ФЛ")] ParseDigitalSignatureFailed = 1050,
        [EnumMember(Value = "Не удалось сгенерировать SMS код")] GenerateSmsCodeFailed = 1052,
        [EnumMember(Value = "Не удалось сгенерировать SMS сообщение")] GenerateSmsMessageFailed = 1053,
        [EnumMember(Value = "Не удалось сгененировать Email код")] GenerateEmailCodeFailed = 1054,
        [EnumMember(Value = "Не удалось хешировать пароль")] HashPasswordFailed = 1055,
        [EnumMember(Value = "Не удалось выполнить валидацию сертификата ЭП")] FailedToValidateDigitalSignatureCertificate = 1056,
        #endregion
        #region[Derzhava.Id.PhysicalPersons]
        [EnumMember(Value = "ФЛ не найдено по отпечатку сертификата")] PhysicalPersonNotFoundByCrtThumbprint = 1100,
        [EnumMember(Value = "ФЛ не найдено по СНИЛС")] PhysicalPersonNotFoundBySnils = 1101,
        [EnumMember(Value = "ФЛ не найдено по ИНН")] PhysicalPersonNotFoundByInn = 1102,
        [EnumMember(Value = "Не удалось привязять ЭП к ФЛ")] DigitalSignatureNotAttachedToPhysicalPerson = 1103,
        [EnumMember(Value = "Не удалось создать ФЛ по ЭП")] PhysicalPersonNotCreatedByDigitalSignature = 1104,
        [EnumMember(Value = "ФЛ не найдено по номеру телефона")] PhysicalPersonNotFoundByPhone = 1105,
        [EnumMember(Value = "ФЛ не найдено по Email")] PhysicalPersonNotFoundByEmail = 1106,
        [EnumMember(Value = "ФЛ не найдено по Email и паролю ")] PhysicalPersonNotFoundByEmailAndPassword = 1107,
        [EnumMember(Value = "ФЛ не найдено по Id")] PhysicalPersonNotFound = 1108,
        [EnumMember(Value = "ЭП не найдена по серийному номеру")] DigitalSignatureNotFoundBySerialNumber = 1109,
        [EnumMember(Value = "ЭП не найдена по слепку")] DigitalSignatureNotFoundByThumbprint = 1100,
        [EnumMember(Value = "ЭП не найдена по Id")] DigitalSignatureNotFound = 1110,
        [EnumMember(Value = "Статус ЭП не был обновлён")] DigitalSignatureStatusNotUpdated = 1111,
        [EnumMember(Value = "Не удалось создать ФЛ по ФИО и ИНН")] PhysicalPersonNotCreatedByFioAndInn = 1112,
        #endregion
        #region[Derzhava.Id.SenderEmail]
        [EnumMember(Value = "Email не отправлен")] EmailNotSent = 1200,
        #endregion
        #region[Derzhava.Id.Derzhava.Id.SenderSms]
        [EnumMember(Value = "Sms не отправлено")] SmsNotSent = 1300,
        #endregion
        #region[Derzhava.Id.Certificates.Validations]
        [EnumMember(Value = "Не удалось провалидировать сертификат ЭП")] DigitalSignatureCertificateNotValidated = 1400,
        #endregion
        #region[Derzhava.Id.PhysicalPersons.Identity.Dp]
        [EnumMember(Value = "Пользователь не найден по Email")] UserNotFound = 1501,
        [EnumMember(Value = "Неверный пароль")] InvalidPasswordPhysicalPersonsIdentity = 1502,
        [EnumMember(Value = "Невалидная полезная нагрузка в токене доступа")] InvalidAccessTokenPayload = 1503,
        [EnumMember(Value = "Рефреш-токен не найден")] RefreshTokenNotFound = 1504,
        [EnumMember(Value = "Время жизни рефреш-токена вышло")] RefreshTokenExpired = 1505,
        [EnumMember(Value = "Идентификация ФЛ не найдена")] PhysicalPersonIdentityNotFound = 1506,
        [EnumMember(Value = "Не удалось сгенерировать данные для подписания")] SigningDataGenerationFailed = 1507,
        [EnumMember(Value = "Неверные границы сортировки по времени")] InvalidUpdateTime = 1514,
        [EnumMember(Value = "Невалидный ИНН")] InvalidInn = 1515,
        [EnumMember(Value = "Неверное количество элементов на странице")] InvalidCount = 1516,
        [EnumMember(Value = "Неверная страница")] InvalidPage = 1517,
        [EnumMember(Value = "Не совпадают данные подписи")] InvalidSignature = 1518,
        #endregion
        #region [Derzhava.Id.Certificates.Validations]
        [EnumMember(Value = "Ключ не прошел проверку на валидность в КриптоПро")] CryptoProValidationFailed = 2000,
        [EnumMember(Value = "Ключ не прошел проверку по ГОСТам")] GostValidationFailed = 2001,
        [EnumMember(Value = "Ключ не прошел проверку по датам")] DateValidationFailed = 2002,
        [EnumMember(Value = "Ключ не прошел проверку во внешних источниках")] ExternalsValidationFailed = 2003,
        [EnumMember(Value = "Существующий сертификат более не актуален")] CertificateIsNotActual = 2004,
        #endregion
        #region [Derzhava.Id.Certificates.Validations.Externals]
        [EnumMember(Value = "Ключ не выдан УЦ")] CertificateIsNotIssuedByCertificationAuthority = 2010,
        [EnumMember(Value = "Ключ отозван")] CertificateIsRevoked = 2011,
        #endregion
        #region [Derzhava.Id.PhysicalPersons.Authorities]
        [EnumMember(Value = "Не удалось выполнить запрос на получение полномочий")] AuthoritiesNotFound = 2700,
        [EnumMember(Value = "Полномочия не найдены в базе данных")] AuthoritiesNoRecordInDb = 2701,
        #endregion
    }
}