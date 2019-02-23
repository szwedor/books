namespace OrderTaking

module Common =
    type Command<'Data> =
        { Data : 'Data
          UserId : string }

    type Undefined = exn

    type AsyncResult<'T, 'TError> =
        Async<Result<'T, 'TError>>
