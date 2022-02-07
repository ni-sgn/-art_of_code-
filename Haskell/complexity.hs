-- The way to build complexity in functional programming is by composition
-- When monads come into play, composition gets tricky
-- imperatively, do this, then this, then this, ... 
-- where then happens when ';' is met 
-- gets complicated functionally, because building blocks 
-- in functional languages are pure functions, we can't do
-- then change the world, there is a restrict that everything 
-- returns something and that something is chained with another thing
-- and therefore chain is constructed, which is basically our program
-- which is going to ultimate goal step-by-step, not touching or 
-- changing anything that doesn't need to be changed.
-- again problem here is how do we create these chains, especially
-- with monads. there must be a way to chain monads


-- Because binding is kind of clear, and normal function composition
-- is also clear, lets analyse do notation in haskell 

-- do notation in haskell is syntax sugar
-- this syntax sugar can turn into to different things

main1 :: IO ()
main1 = do
	putStrLn "Hello "
	putStrLn "World"

-- This turns into
main1 = putStrLn "Hello " >> putStrLn "World"

-- Second case, although, I'm not quite sure of this
-- this needs proof, and testing
main2 :: IO ()
main2 = do
	var <- getLine 
	putStrLn var

-- This turns into
main2 = getLine >>= \val -> putStrLn val   

