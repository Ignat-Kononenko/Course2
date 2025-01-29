document.addEventListener('DOMContentLoaded', function () {
    const taskInput = document.getElementById('inputBox');
    const addButton = document.getElementById('addButton');
    const taskList = document.getElementById('listContainer');
    const showAllButton = document.getElementById('showAllButton');
    const showCompletedButton = document.getElementById('showCompletedButton');
    const showPendingButton = document.getElementById('showPendingButton');

    class Task {
        constructor(id, name, state) {
            this.id = id;
            this.name = name;
            this.state = state;
        }

        changeName(name) {
            this.name = name;
        }

        changeState(state) {
            this.state = state;
        }
    }

    class Todolist {
        constructor(id, name) {
            this.id = id;
            this.name = name;
            this.tasks = [];
        }

        updateName(newName) {
            this.name = newName;
        }

        addTask(task) {
            this.tasks.push(task);
        }

        removeTask(id) {
            this.tasks = this.tasks.filter(task => task.id !== id);
        }

        editTask(id, newName) {
            let task = this.tasks.find(task => task.id === id);
            if (task) {
                task.changeName(newName);
            }
        }

        toggleTaskCompletion(id) {
            let task = this.tasks.find(task => task.id === id);
            if (task) {
                task.changeState(!task.state);
            }
        }

        getFilter(isComplete) {
            return this.tasks.filter(task => task.state === isComplete);
        }

        getAllTasks() {
            return this.tasks;
        }
    }

    let todoList = new Todolist(1, 'TodoList');

    function renderTasks(filter = 'all') {
        taskList.innerHTML = '';
        let tasks = [];
        if (filter === 'all') {
            tasks = todoList.getAllTasks();
        } else if (filter === 'completed') {
            tasks = todoList.getFilter(true);
        } else if (filter === 'pending') {
            tasks = todoList.getFilter(false);
        }

        tasks.forEach(task => {
            const li = document.createElement('li');
            li.className = 'content';

            const checkbox = document.createElement('input');
            checkbox.type = 'checkbox';
            checkbox.className = 'checkBox';
            checkbox.checked = task.state;
            checkbox.addEventListener('change', () => {
                todoList.toggleTaskCompletion(task.id);
                renderTasks(filter);
            });

            const taskName = document.createTextNode(task.name);

            const buttonContainer = document.createElement('div');
            buttonContainer.className = 'twoButtons';

            const editButton = document.createElement('button');
            editButton.className = 'editButton';
            editButton.textContent = 'Редактировать';
            editButton.addEventListener('click', () => {
                const newTaskName = prompt('Изменить имя задания:', task.name);
                if (newTaskName !== null && newTaskName.trim() !== '') {
                    todoList.editTask(task.id, newTaskName.trim());
                    renderTasks(filter);
                }
            });

            const removeButton = document.createElement('button');
            removeButton.className = 'removeButton';
            removeButton.textContent = 'Удалить';
            removeButton.addEventListener('click', () => {
                todoList.removeTask(task.id);               // Удаление задачи из списка
                li.remove();                                // Удаление элемента списка из DOM
            });

            buttonContainer.append(editButton);
            buttonContainer.append(removeButton);

            li.append(checkbox);
            li.append(taskName);
            li.append(buttonContainer);

            taskList.append(li);
        });
    }

    addButton.addEventListener('click', () => {
        const taskName = taskInput.value.trim();
        if (taskName) {
            const taskId = todoList.getAllTasks().length + 1;
            todoList.addTask(new Task(taskId, taskName, false));
            taskInput.value = '';
            renderTasks();
        }
    });

    showAllButton.addEventListener('click', () => renderTasks('all'));
    showCompletedButton.addEventListener('click', () => renderTasks('completed'));
    showPendingButton.addEventListener('click', () => renderTasks('pending'));

    renderTasks();
});
