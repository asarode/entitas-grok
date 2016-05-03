//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentExtensionsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Entitas {
    public partial class Entity {
        public InputComponent input { get { return (InputComponent)GetComponent(ComponentIds.Input); } }

        public bool hasInput { get { return HasComponent(ComponentIds.Input); } }

        public Entity AddInput(int newX, int newY) {
            var component = CreateComponent<InputComponent>(ComponentIds.Input);
            component.x = newX;
            component.y = newY;
            return AddComponent(ComponentIds.Input, component);
        }

        public Entity ReplaceInput(int newX, int newY) {
            var component = CreateComponent<InputComponent>(ComponentIds.Input);
            component.x = newX;
            component.y = newY;
            ReplaceComponent(ComponentIds.Input, component);
            return this;
        }

        public Entity RemoveInput() {
            return RemoveComponent(ComponentIds.Input);
        }
    }

    public partial class Pool {
        public Entity inputEntity { get { return GetGroup(Matcher.Input).GetSingleEntity(); } }

        public InputComponent input { get { return inputEntity.input; } }

        public bool hasInput { get { return inputEntity != null; } }

        public Entity SetInput(int newX, int newY) {
            if (hasInput) {
                throw new EntitasException("Could not set input!\n" + this + " already has an entity with InputComponent!",
                    "You should check if the pool already has a inputEntity before setting it or use pool.ReplaceInput().");
            }
            var entity = CreateEntity();
            entity.AddInput(newX, newY);
            return entity;
        }

        public Entity ReplaceInput(int newX, int newY) {
            var entity = inputEntity;
            if (entity == null) {
                entity = SetInput(newX, newY);
            } else {
                entity.ReplaceInput(newX, newY);
            }

            return entity;
        }

        public void RemoveInput() {
            DestroyEntity(inputEntity);
        }
    }

    public partial class Matcher {
        static IMatcher _matcherInput;

        public static IMatcher Input {
            get {
                if (_matcherInput == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Input);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherInput = matcher;
                }

                return _matcherInput;
            }
        }
    }
}