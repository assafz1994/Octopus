grammar OctopusQL;

/*
 * Parser Rules
 */

r                   : select | insert | delete | update;
select              : FROM entity entityRep (whereClause)* (selectClause | aggregateClause) ;
deleteSelect        : FROM entity entityRep (whereClause)* ;
insert              : (insertClause)+ INSERT entityReps ;
delete              : DELETE deleteSelect ;
update              : (getClause)+ UPDATE entityRep (fieldsWithDot)? ASSIGN value ;
insertClause        : ENTITY entity COLON entityRep '(' (assignments | select) ')' ;
getClause           : ENTITY entity COLON entityRep '(' select ')' ;
assignments         : assignmentList+=assignment (',' assignmentList+=assignment)* ;
assignment          : field EQUALS value ;
whereClause         : PIPELINE WHERE entityRep fieldsWithDot COMPARATOR value ;
fieldsWithDot       : ('.' el+=field)+ ;
fields              : fieldList+=field (',' fieldList+=field)* ;
entityReps          : entityRepList+=entityRep (',' entityRepList+=entityRep)* ;
selectClause        : PIPELINE SELECT entityRep (fieldsWithDot)? '(' (fields | all)? ')' (include)* ;
include             : INCLUDE '(' field '(' (fields | all)? ')' (include)* ')' ;
aggregateClause     : PIPELINE func '(' entityRep '(' field ')' ')' ;
values              : valueList+=value (',' valueList+=value)* ;
array               : '[' (values)? ']' ;
func                : 'AVG' | 'SUM' | 'MIN' | 'MAX' ;
field               : WORD ;
value               : '(' select ')' | WORD | TEXT | NUMBER | ENTREP | array;
entity              : WORD ;
entityRep           : ENTREP | WORD;
all                 : '*' ;
/*
 * Lexer Rules
 */

EQUALS              : '=' ;
ASSIGN              : EQUALS | ADD | REMOVE ;
COMPARATOR          : ISEQUALS | GT | GTE | LT | LTE ; 
SELECT              : 'select' | 'SELECT' | 'Select' ;
FROM                : 'from' | 'FROM' | 'From' ;
WHERE               : 'where' | 'WHERE' | 'Where' ;
INCLUDE             : 'include' | 'INCLUDE' | 'Include' ;
ENTITY              : 'entity' | 'ENTITY' | 'Entity' ;
INSERT              : 'insert' | 'INSERT' | 'Insert' ;
DELETE              : 'delete' | 'DELETE' | 'Delete' ;
UPDATE              : 'update' | 'UPDATE' | 'Update' ;
PIPELINE            : '|' ;
COLON               : ':' ;
ISEQUALS            : '==' ;

GT                  : '>' ;
GTE                 : '>=' ;
LT                  : '<' ;
LTE                 : '<=' ; 
ADD                 : '+=' ;
REMOVE              : '-=' ;
fragment LOWERCASE  : [a-z] ;
fragment UPPERCASE  : [A-Z] ;
WORD                : (LOWERCASE | UPPERCASE)+ ;
NUMBER              : [0-9]+ ;
ENT                 : [A-Z][a-z]* ;
ENTREP              : [a-z]+[0-9]* ;

TEXT                : '"' .*? '"' ;
WHITESPACE          :  [ \t\r\n]+ -> skip ;