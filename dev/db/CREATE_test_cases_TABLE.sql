CREATE TABLE "test_cases" (
	"id"	INTEGER,
	"test_name"	TEXT NOT NULL,
	"summary"	TEXT NOT NULL,
	"detail"	TEXT NOT NULL,
	"base_test_id"	INTEGER DEFAULT -1,
	"test_case_version"	INTEGER DEFAULT 1,
	"created_at"	TEXT DEFAULT CURRENT_TIMESTAMP,
	"updated_at"	TEXT DEFAULT CURRENT_TIMESTAMP,
	FOREIGN KEY("base_test_id") REFERENCES "test_cases"("id") ON UPDATE CASCADE,
	PRIMARY KEY("id")
);
