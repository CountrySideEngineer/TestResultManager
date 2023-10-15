CREATE TABLE "products" (
	"id"	INTEGER,
	"name"	TEXT NOT NULL UNIQUE,
	"created_at"	TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
	"updated_at"	TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
	PRIMARY KEY("id")
);

CREATE TABLE "functions" (
	"id" INTEGER, "name" TEXT NOT NULL UNIQUE, 
	"created_at" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP, 
	"updated_at" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP, 
	PRIMARY KEY("id")
);

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

CREATE TABLE "test_execution_types" (
	"id"	INTEGER,
	"type_text"	TEXT NOT NULL UNIQUE,
	"is_run"	INTEGER DEFAULT 0,
	"created_at"	TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
	"updated_at"	TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
	PRIMARY KEY("id" AUTOINCREMENT)
);

CREATE TABLE "test_levels" (
	"id"	INTEGER,
	"name"	TEXT NOT NULL UNIQUE,
	"created_at"	TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
	"updated_at"	TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
	PRIMARY KEY("id")
);

CREATE TABLE "test_result_codes" (
	"id"	INTEGER,
	"result_text"	TEXT NOT NULL UNIQUE,
	"created_at"	TEXT DEFAULT CURRENT_TIMESTAMP,
	"updated_at"	TEXT DEFAULT CURRENT_TIMESTAMP,
	PRIMARY KEY("id" AUTOINCREMENT)
);

CREATE TABLE "testers" (
	"id"	INTEGER,
	"tester_code"	TEXT NOT NULL UNIQUE,
	"company"	TEXT NOT NULL,
	"section"	TEXT NOT NULL,
	"name"	TEXT NOT NULL,
	"created_at"	TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
	"updated_at"	TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
	PRIMARY KEY("id" AUTOINCREMENT)
);

CREATE TABLE "test_versions" (
	"id"	INTEGER,
	"version_code"	TEXT NOT NULL,
	"previous_version_code_id"	INTEGER DEFAULT 0,
	"products_id"	INTEGER NOT NULL DEFAULT 0,
	"created_at"	TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
	"updated_at"	TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
	PRIMARY KEY("id"),
	FOREIGN KEY("products_id") REFERENCES "products"("id") ON UPDATE CASCADE,
	FOREIGN KEY("previous_version_code_id") REFERENCES "test_versions"("id") ON UPDATE CASCADE ON DELETE SET NULL,
	UNIQUE("version_code","products_id")
);

CREATE TABLE "test_results" (
	"id"	INTEGER,
	"products_id"	INTEGER,
	"functions_id"	INTEGER,
	"test_levels_id"	INTEGER,
	"test_cases_id"	INTEGER,
	"test_versions_id"	INTEGER,
	"test_execution_types_id"	INTEGER,
	"test_result_codes_id"	INTEGER,
	"testers_id"	INTEGER,
	"executed_at"	TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
	"created_at"	TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
	"updated_at"	TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
	FOREIGN KEY("test_cases_id") REFERENCES "test_cases"("id") ON UPDATE CASCADE ON UPDATE CASCADE ON DELETE SET NULL,
	FOREIGN KEY("test_levels_id") REFERENCES "test_levels"("id") ON UPDATE CASCADE ON UPDATE CASCADE ON DELETE SET NULL,
	FOREIGN KEY("test_execution_types_id") REFERENCES "test_execution_types"("id") ON UPDATE CASCADE ON UPDATE CASCADE ON DELETE SET NULL,
	FOREIGN KEY("functions_id") REFERENCES "functions"("id") ON UPDATE CASCADE ON DELETE SET NULL,
	FOREIGN KEY("test_versions_id") REFERENCES "test_levels"("id") ON UPDATE CASCADE ON UPDATE CASCADE ON DELETE SET NULL,
	FOREIGN KEY("products_id") REFERENCES "products"("id") ON UPDATE CASCADE ON DELETE SET NULL,
	FOREIGN KEY("test_result_codes_id") REFERENCES "test_result_codes"("id") ON UPDATE CASCADE ON UPDATE CASCADE ON DELETE SET NULL,
	FOREIGN KEY("testers_id") REFERENCES "testers"("id") ON UPDATE CASCADE ON DELETE SET NULL,
	PRIMARY KEY("id" AUTOINCREMENT)
);
