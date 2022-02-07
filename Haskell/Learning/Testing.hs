import Data.Maybe
import Control.Applicative

-- Most important stuff in FP(compositions)

mySum :: Int -> Int -> Int
mySum a b = a + b

myConverter :: Int -> String
myConverter 5 = "Lucky Number 5" 
myConverter a = "Something that is not 5"

myComposition :: (Int -> String) -> (Int -> Int -> Int) -> Int -> Int -> String
myComposition f g a b  = (f . (g a)) b

safeMySum :: Int -> Int -> Maybe Int
safeMySum 666 b = Nothing
safeMySum a 666 = Nothing 
safeMySum a b = return (mySum a b)

-- apperently flattening monads like this is a bad practice 
safeSumUnwrapper :: Maybe Int -> String 
safeSumUnwrapper Nothing = "Bruh, This ain't it, God gonna get Maaad Mad!"
safeSumUnwrapper (Just a) = "You coo with me cuh!"


main :: IO ()
-- <- this operator is only for IO actions
main = do 
    -- better way to flatten monads
    let coughtMonad = safeMySum 2 666 
    case coughtMonad of
        Just a -> putStrLn "Glad you picked a Godly number"
        Nothing -> putStrLn "God isn't with you"
    putStrLn $ myConverter $ mySum 2 5
    putStrLn (myConverter (mySum 2 3)) 
    putStrLn (myComposition myConverter mySum 2 3 )
    putStrLn $ safeSumUnwrapper $ safeMySum 2 3
    -- composing ACTIONS
    actionForFunctors


-- when we have a function on flatten types, but input is lifted
-- then we have to fmap, somehow apply the original function to the lifted value
-- that's basically an fmap
-- lifted(maybe as a functor in this case) type itself has a contract, to contain fmap

manipulateData :: Int -> Int 
manipulateData a = a + 3

filterData :: Int -> Maybe Int 
filterData a  
    | a > 10 = Just a
    | a > 5 = Just (a - 1)
    | otherwise = Nothing 


actionForFunctors :: IO ()
actionForFunctors = (putStrLn $ show $ manipulateData <$> filterData 3) >> putStrLn "This works like a charm!" 


-- Functions(their types) can also be lifted(wrapped in context)
-- there must be a way to apply lifted functions to the lifted values
-- Applicatives have this contract
