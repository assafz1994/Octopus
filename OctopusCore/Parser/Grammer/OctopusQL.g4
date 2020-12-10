grammar OctopusQL;

/*
 * Parser Rules
 */

r                   : select ;
select              : FROM entity entityRep (whereClause)* (selectClause | aggregateClause) ;
whereClause         : PIPELINE WHERE entityRep attributesWithDot COMPARISON value ;
attributesWithDot   : ('.' el+=attribute)+ ;
attributes          : attrList+=attribute (',' attrList+=attribute)* ;
selectClause        : PIPELINE SELECT entityRep (attributesWithDot)? '(' (attributes | all)? ')' (include)* ;
include             : INCLUDE '(' attribute '(' (attributes | all)? ')' (include)* ')' ;
aggregateClause     : PIPELINE func '(' entityRep '(' attribute ')' ')' ;
func                : 'AVG' | 'SUM' | 'MIN' | 'MAX' ;
attribute           : WORD ;
value               : WORD | TEXT | NUMBER;
entity              : WORD ;
entityRep           : ENTREP | WORD;
all : '*' ;
/*
 * Lexer Rules
 */

COMPARISON : EQUALS | GT | GTE | LT | LTE ; 
SELECT : 'select' | 'SELECT' | 'Select' ;
FROM : 'from' | 'FROM' | 'From' ;
WHERE : 'where' | 'WHERE' | 'Where' ;
INCLUDE : 'include' | 'INCLUDE' | 'Include' ;
PIPELINE : '|' ;
EQUALS : '==' ;
GT : '>' ;
GTE : '>=' ;
LT : '<' ;
LTE : '<=' ; 
fragment A          : ('A'|'a') ;
fragment C          : ('C'|'c') ;
fragment S          : ('S'|'s') ;
fragment Y          : ('Y'|'y') ;
fragment H          : ('H'|'h') ;
fragment O          : ('O'|'o') ;
fragment U          : ('U'|'u') ;
fragment T          : ('T'|'t') ;
fragment F          : ('F'|'f') ;
fragment R          : ('R'|'r') ;
fragment M          : ('M'|'m') ;
fragment W          : ('W'|'w') ;
fragment E          : ('E'|'e') ;

fragment LOWERCASE  : [a-z] ;
fragment UPPERCASE  : [A-Z] ;
WORD                : (LOWERCASE | UPPERCASE)+ ;
NUMBER              : [0-9]+ ;
ENT           : [A-Z][a-z]* ;
ENTREP           : [a-z]+[0-9]* ;

TEXT                : '"' .*? '"' ;
WHITESPACE          :  [ \t\r\n]+ -> skip ;