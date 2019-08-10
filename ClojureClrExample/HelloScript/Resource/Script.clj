(ns ScriptNs)

(defn greet [name] (str "Hello, " name))

(def obj (new HelloScript.HelloClass))

(defn obj2 [] (HelloScript.HelloClass.))
