import Data.List

queueTime :: [Int] -> Int -> Int
queueTime xs n =  thrd $ h ((take n xs), (reverseTake n xs), 0) 

h :: ([Int] , [Int] , Int) -> ([Int], [Int], Int)
h ([], _, 0) = ([], [], 0)
h (xs, [], accum) = ([], [], accum + maximum xs) 
h (xs, ys, accum) = h ( b, c, accum + minimum xs)
    where
        a = rz ([x - minimum xs | x<-xs], ys)
        b = fst a 
        c = snd a


thrd :: ([a], [a], a) -> a
thrd (as, bs, c) = c

reverseTake :: Int -> [Int] -> [Int]
reverseTake n xs = reverse $ take ((length xs) - n) (reverse xs)


-- this can be asynchronous, divided into two functions
rz :: ([Int], [Int]) -> ([Int], [Int])
rz ([], a) = ([], a)
rz (a, []) = (a, [])
rz (xs, ys) 
    | head sorted == 0 = (head ys : (fst $ rz ((tail sorted), (tail ys))), (snd $ rz ((tail sorted), (tail ys)))) 
    | otherwise = (sorted, ys)
    where 
        sorted = sort xs

main :: IO()
main = do
    putStrLn $ show $ queueTime [1,5,1,1,1,1,1] 2 

