1)"Yes, don't unit test private methods.... The idea of a unit test is to test the unit by its public 'API'.

If you are finding you need to test a lot of private behavior, most likely you have a new 'class' hiding within the class you are trying to test, extract it and test it by its public interface" - from stack overflow. some poeple just make it simple and think that most methods should be public.

