
DELETE FROM department;

INSERT INTO department (name)
VALUES 
    ('Parks and Recreation')
    ,('Sewage')
    ,('Mayor''s Office')
    ,('Fire Department')
    ,('Library')
;

DELETE FROM designation;

INSERT INTO designation (title)
VALUES 
    ('Director')
    ,('Deputy Director')
    ,('Assistant')
;

DELETE FROM employee;

SELECT *
FROM department;

SELECT *
FROM designation;
