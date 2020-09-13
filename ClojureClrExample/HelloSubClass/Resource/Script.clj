(ns ScriptNs)

(defn create-base
  []
  (HelloSubClass.BaseClass.))

(defn create-sub
  []

  (proxy [HelloSubClass.BaseClass] []
    ;; override StringProperty getter
    (get_StringProperty [] "Sub String Property")
    ;; override Method1
    (Method1 [] "Sub Method1")))
