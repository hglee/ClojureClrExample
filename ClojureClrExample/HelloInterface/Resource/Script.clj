(ns ScriptNs)

;; by proxy
(defn create-impl1
  []
  (proxy [HelloInterface.IGreet] []
    (get_GreetMessage [] "Greet1 by property.")
    (Greet [] "Greet1 by method")))

;; by deftype
(deftype Impl2 []
  HelloInterface.IGreet
  (get_GreetMessage [this] "Greet2 by property.")
  (Greet [this] "Greet2 by method"))

(defn create-impl2
  []
  (Impl2.))
