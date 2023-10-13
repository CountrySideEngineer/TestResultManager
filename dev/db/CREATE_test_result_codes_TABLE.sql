CREATE TABLE "test_result_codes" (
	"id"	INTEGER,
	"result_text"	TEXT NOT NULL UNIQUE,
	"created_at"	TEXT DEFAULT CURRENT_TIMESTAMP,
	"updated_at"	TEXT DEFAULT CURRENT_TIMESTAMP,
	PRIMARY KEY("id" AUTOINCREMENT)
);
