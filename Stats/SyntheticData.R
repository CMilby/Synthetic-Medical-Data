setwd("/Users/Craig/Projects/MedicalDataGeneration/Data/")

library(readr)
library(ggplot2)

df <- read_csv("data.csv", col_names = TRUE)
#summary(df)

hb <- df[ df$Systolic > 140, ]
q1 <- df [ c( 1:1250000 ), ]
q2 <- df [ c( 1250001:2500000), ];
q3 <- df [ c( 2500001: 3750000), ];
q4 <- df [ c( 3750001:5000000), ];
print( NROW( q1[ q1$Systolic > 140, ] ) )
print( NROW( q2[ q2$Systolic > 140, ] ) )
print( NROW( q3[ q3$Systolic > 140, ] ) )
print( NROW( q4[ q4$Systolic > 140, ] ) )
rm( hb, q1, q2, q3, q4 )

males <- df[ df$Sex == 'MALE', ]
myData = data.frame( males$Systolic, males$Percentile )
a <- males$Systolic
b <- males$Percentile
hNA <- males[ !is.na( males$Risk ), ]
hSmoke <- hNA[ hNA$Risk == 'HEAVY_SMOKER', ]
c <- hSmoke$Systolic
d <- hSmoke$Percentile
hDrink <- hNA[ hNA$Risk == 'HEAVY_DRINKER', ]
e <- hDrink$Systolic;
f <- hDrink$Percentile;
hBoth <- hNA[ hNA$Risk == 'HEAVY_SMOKER|HEAVY_DRINKER', ]
g <- hBoth$Systolic
h <- hBoth$Percentile

ggplot(myData,aes(x=b,y=a)) +
  geom_point(colour="blue") +
  geom_point(data=hSmoke, aes(x=d,y=c), colour="red") +
  geom_point(data=hDrink, aes(x=f,y=e), colour="green") +
  geom_point(data=hBoth, aes(x=h,y=g), colour="yellow")
rm( a, b, c, d, e, f, g, h, hSmoke, hDrink, hBoth, hNA, myData )

states <- map_data("state")
states_simple <- subset(states, !duplicated(region)) 
states$percent = 0.0

for ( i in 1:NROW(states_simple) ) {
  sData <- df[ tolower( df$State ) == states_simple[ i, ]$region, ]
  highBlood <- NROW(sData[sData$Systolic > 120,])
  percent <- as.double(highBlood)/as.double(NROW(sData))
  states[ states$region == states_simple[ i, ]$region, ]$percent = percent;
}

rm( i, sData, highBlood, percent, states_simple )

ggplot(data = states) + 
  geom_polygon(aes(x = long, y = lat, fill = percent, group = group), color = "white") + 
  coord_fixed(1.3) +
  guides(fill=FALSE)


states_simple <- subset(states, !duplicated(region)) 
states_simple <- states_simple[ !is.nan( states_simple$percent ), ]
mean( states_simple$percent )

states_simple[ states_simple$region == "west virginia", ]
