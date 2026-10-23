#pragma once
#ifndef _{PLUGIN_SETTINGS_
#define _PLUGIN_SETTINGS_
	#ifdef PLUGIN_EXPORTS
	#define PLUGIN_API _declspec(dllexport)
	#elif PLUGIN_IMPORTS
	#define PLUGIN_API _declspec(dllimport)
	#else
	#define PLUGIN_API
	#endif
#endif /*defined (_PLUGIN_SETTINGS_) */