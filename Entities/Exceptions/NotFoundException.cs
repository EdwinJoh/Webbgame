namespace Entities.Exceptions;

public abstract class NotFoundException : Exception
{
    protected NotFoundException(string message) : base(message)
    {
    }
}

public abstract class BadRequestException : Exception
{
    protected BadRequestException(string message) : base(message)
    {
    }
}