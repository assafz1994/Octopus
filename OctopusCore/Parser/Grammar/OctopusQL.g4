grammar OctopusQL;

/*
 * Parser Rules
 */

r                   : select | insert | delete;
select              : FROM entity entityRep (whereClause)* (selectClause | aggregateClause) ;
insert : (insertClause)+ INSERT entityReps ;
delete : (deleteClause)+ DELETE entityReps ;
insertClause : ENTITY entity COLON entityRep '(' (assignments | select) ')' ;
deleteClause : ENTITY entity COLON entityRep '(' select ')' ;
assignments : assignmentList+=assignment (',' assignmentList+=assignment)* ;
assignment : field EQUALS value ;
whereClause         : PIPELINE WHERE entityRep fieldsWithDot COMPARATOR value ;
fieldsWithDot   : ('.' el+=field)+ ;
fields          : fieldList+=field (',' fieldList+=field)* ;
entityReps : entityRepList+=entityRep (',' entityRepList+=entityRep)* ;
selectClause        : PIPELINE SELECT entityRep (fieldsWithDot)? '(' (fields | all)? ')' (include)* ;
include             : INCLUDE '(' field '(' (fields | all)? ')' (include)* ')' ;
aggregateClause     : PIPELINE func '(' entityRep '(' field ')' ')' ;
values : valueList+=value (',' valueList+=value)* ;
array : '[' (values)? ']' ;
func                : 'AVG' | 'SUM' | 'MIN' | 'MAX' ;
field           : WORD ;
value               : select | WORD | TEXT | NUMBER | ENTREP | array;
entity              : WORD ;
entityRep           : ENTREP | WORD;
all : '*' ;
/*
 * Lexer Rules
 */

COMPARATOR : ISEQUALS | GT | GTE | LT | LTE ; 
SELECT : 'select' | 'SELECT' | 'Select' ;
FROM : 'from' | 'FROM' | 'From' ;
WHERE : 'where' | 'WHERE' | 'Where' ;
INCLUDE : 'include' | 'INCLUDE' | 'Include' ;
ENTITY : 'entity' | 'ENTITY' | 'Entity' ;
INSERT : 'insert' | 'INSERT' | 'Insert' ;
DELETE : 'delete' | 'DELETE' | 'Delete' ;
PIPELINE : '|' ;
COLON : ':' ;
ISEQUALS : '==' ;
EQUALS : '=' ;
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